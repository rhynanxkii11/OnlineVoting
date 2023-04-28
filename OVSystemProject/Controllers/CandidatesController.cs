using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using OVSystemProject.Data;
using OVSystemProject.Models;
using OVSystemProject.ViewModels;
using System.Data;
using System.Net.Cache;

namespace OVSystemProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CandidatesController : Controller
    {
        private readonly OnlineVotingDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CandidatesController(OnlineVotingDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<Candidates> candidates = await _context.Candidates.ToListAsync();
                //var candidates = await _context.Candidates.ToListAsync();
                return View(candidates);
            }
             catch (Exception ex)
             {
                 TempData["errorMessage"] = ex.Message.ToString();
                 return RedirectToAction("Index", "Admin");
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CandidatesViewModel viewModel = new CandidatesViewModel
            {
                CandidateViewModel = new CandidateViewModel(),
                Positions = _context.Positions.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CandidatesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string photoFile = string.Empty;

                if (viewModel.CandidateViewModel.Photo != null)
                {
                    photoFile = UploadedPhoto(viewModel.CandidateViewModel.Photo);
                }

                var candidate = new Candidates
                {
                    FirstName = viewModel.CandidateViewModel.FirstName,
                    MiddleName = viewModel.CandidateViewModel.MiddleName,
                    LastName = viewModel.CandidateViewModel.LastName,
                    NameExtension = viewModel.CandidateViewModel.NameExtension,
                    DateOfBirth = viewModel.CandidateViewModel.DateOfBirth,
                    Age = viewModel.CandidateViewModel.Age,
                    Sex = viewModel.CandidateViewModel.Sex,
                    Photo = photoFile,
                    CivilStatus = viewModel.CandidateViewModel.CivilStatus,
                    Citizenship = viewModel.CandidateViewModel.Citizenship,
                    PositionId = viewModel.CandidateViewModel.PositionId,
                    Party = viewModel.CandidateViewModel.Party
                };

                _context.Candidates.Add(candidate);
                await _context.SaveChangesAsync();
                TempData["successMessage"] = "New candidate has been added successfully!";
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["errorMessage"] = "Id is not found!";
                return View();
            }
            //var candidate = from c in _context.Candidates
            //                where c.CandidateId == id
            //                select c;

            //var candidate = await _context.Candidates.FindAsync(id);

            var candidate = await _context.Candidates.Include(c => c.Positions).FirstOrDefaultAsync(c => c.CandidateId == id);

            if (candidate == null)
            {
                TempData["errorMessage"] = "Candidate is not found!";
                return View();
            }
            return View(candidate);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null || id == 0)
            {
                TempData["errorMessage"] = "Id is not found!";
                return View();
            }

            var candidate = await _context.Candidates.Include(c => c.Positions).FirstOrDefaultAsync(c => c.CandidateId == id);

            if (candidate == null)
            {
                TempData["errorMessage"] = "Candidate is not found!";
                return View();
            }


            var candidateViewModel = new CandidateViewModel
            {
                CandidateId = candidate.CandidateId,
                FirstName = candidate.FirstName,
                MiddleName = candidate.MiddleName,
                LastName = candidate.LastName,
                NameExtension = candidate.NameExtension,
                DateOfBirth = candidate.DateOfBirth,
                Age = candidate.Age,
                Sex = candidate.Sex,
                CivilStatus = candidate.CivilStatus,
                Citizenship = candidate.Citizenship,
                PositionId = candidate.PositionId,
                Party = candidate.Party
            };
            List<Positions> positions = await _context.Positions.ToListAsync();
            ViewBag.CandidatePositions = positions;
            
            return View(candidateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CandidateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //string? updateUniquePhoto = null;
                //string? updatePhoto = null;
                var candidate = await _context.Candidates.FindAsync(id);

                if (candidate == null)
                {
                    TempData["errorMessage"] = "Candidate is not found!";
                    return View();
                }

                //if (viewModel.CandidateViewModel.Photo != null)
                //{
                //    updateUniquePhoto = UploadedPhoto(viewModel.CandidateViewModel.Photo);
                //    updatePhoto = candidate.Photo;
                //}

                if(viewModel.Photo != null)
                {
                    if (!string.IsNullOrWhiteSpace(candidate.Photo))
                    {
                        var photoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/candidate", candidate.Photo);
                        if (System.IO.File.Exists(photoPath))
                        {
                            System.IO.File.Delete(photoPath);
                        }
                    }
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(viewModel.Photo.FileName);
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/candidate", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewModel.Photo.CopyToAsync(fileStream);
                    }

                    candidate.Photo = fileName;
                }
                
                candidate.FirstName = viewModel.FirstName;
                candidate.MiddleName = viewModel.MiddleName;
                candidate.LastName = viewModel.LastName;
                candidate.NameExtension = viewModel.NameExtension;
                candidate.DateOfBirth = viewModel.DateOfBirth;
                candidate.Age = viewModel.Age;
                candidate.Sex = viewModel.Sex;
                candidate.CivilStatus = viewModel.CivilStatus;
                candidate.Citizenship = viewModel.Citizenship;
                candidate.PositionId = viewModel.PositionId;
                candidate.Party = viewModel.Party;


                await _context.SaveChangesAsync();
                TempData["successMessage"] = "Candidate has been updated successfully!";
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null || id == 0)
            {
                TempData["errorMessage"] = "Id is not found!";
                return View();
            }

            var candidate = await _context.Candidates.Include(c => c.Positions).FirstOrDefaultAsync(c => c.CandidateId == id);

            if (candidate == null)
            {
                TempData["errorMessage"] = "Candidate is not found!";
                return View();
            }

            var candidateViewModel = new CandidateViewModel
            {
                CandidateId = candidate.CandidateId,
                FirstName = candidate.FirstName,
                MiddleName = candidate.MiddleName,
                LastName = candidate.LastName,
                NameExtension = candidate.NameExtension,
                DateOfBirth = candidate.DateOfBirth,
                Age = candidate.Age,
                Sex = candidate.Sex,
                CivilStatus = candidate.CivilStatus,
                Citizenship = candidate.Citizenship,
                PositionId = candidate.PositionId,
                Party = candidate.Party
            };

            CandidatesViewModel viewModel = new CandidatesViewModel
            {
                CandidateViewModel = candidateViewModel,
                Positions = _context.Positions.ToList()
            };
            return View(viewModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            
            if (id == null || id == 0)
            {
                TempData["errorMessage"] = "Id is not found!";
                return View();
            }

            var candidate = await _context.Candidates.Include(c => c.Positions).FirstOrDefaultAsync(c => c.CandidateId == id);
            if(candidate == null)
            {
                TempData["errorMessage"] = "Candidate is not found!";
                return View();
            }

            var photoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/candidate", candidate.Photo);
            if (System.IO.File.Exists(photoPath))
            {
                System.IO.File.Delete(photoPath);
            }

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
            TempData["successMessage"] = "Candidate has been deleted successfully!";
            return RedirectToAction("Index");
        }
        private string UploadedPhoto(IFormFile photo)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img/candidate");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
    }
}
