using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OVSystemProject.Data;
using OVSystemProject.Models;
using System.Data;

namespace OVSystemProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ElectionEventController : Controller
    {
        private readonly OnlineVotingDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ElectionEventController(OnlineVotingDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ElectionEvent> electionEvent = await _context.ElectionEvent.ToListAsync();
            return View(electionEvent);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ElectionEvent electionEvent)
        {
            if(_context.ElectionEvent.Count() > 0)
            {
                TempData["errorMessage"] = "There is still an existing election event!";
                return View();
            }
            _context.ElectionEvent.Add(electionEvent);
            TempData["successMessage"] = "Election event has been added successfully!";
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["errorMessage"] = "Id is not found!";
                return View();
            }
            var election = await _context.ElectionEvent.FindAsync(id);

            if (election == null)
            {
                TempData["errorMessage"] = "Candidate is not found!";
                return View();
            }
            return View(election);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, ElectionEvent updatedEvent)
        {
            if(ModelState.IsValid)
            {
                var existingEvent = await _context.ElectionEvent.FindAsync(id);

                if (existingEvent.StartDate == updatedEvent.StartDate && existingEvent.EndDate == updatedEvent.EndDate)
                {
                    TempData["errorMessage"] = "No changes made";
                    return RedirectToAction("Index");
                }
                existingEvent.StartDate = updatedEvent.StartDate;
                existingEvent.EndDate = updatedEvent.EndDate;

                await _context.SaveChangesAsync();
                TempData["successMessage"] = "Election event has been updated successfully";
                return RedirectToAction("Index");
            }
            return View(updatedEvent);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["errorMessage"] = "Id is not found!";
                return View();
            }
            var election = await _context.ElectionEvent.FindAsync(id);

            if (election == null)
            {
                TempData["errorMessage"] = "Event is not found!";
                return View();
            }
            return View(election);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var existingEvent = await _context.ElectionEvent.FindAsync(id);

            if(existingEvent.EndDate > DateTime.Now) 
            {
                TempData["errorMessage"] = "Cannot delete the election event!";
                return RedirectToAction("Index");
            }
            if (existingEvent == null)
            {
                TempData["errorMessage"] = "Election event is not found!";
                return View();
            }
            _context.ElectionEvent.Remove(existingEvent);

            await _context.SaveChangesAsync();
            TempData["successMessage"] = "Election event has been deleted successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ResetData()
        {
            if (_context.ElectionEvent.Count() > 0)
            {
                TempData["errorMessage"] = "There is still an existing election event!";
                return RedirectToAction("Index", "ElectionEvent");
            }
            return View();
        }
        [ActionName("ResetData")]
        [HttpPost]
        public async Task<IActionResult> ResetDataConfirm()
        {
            var candidates = _context.Candidates.ToList();
            foreach (var candidate in candidates)
            {
                if (!string.IsNullOrWhiteSpace(candidate.Photo))
                {
                    var photoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/candidate", candidate.Photo);
                    if (System.IO.File.Exists(photoPath))
                    {
                        System.IO.File.Delete(photoPath);
                    }
                }
            }
            // Delete the data from tables Position, Candidate, Event, and VoteTransaction
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM Positions");
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM Candidates");
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM ElectionEvent");
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM VoteTransactions");

            // Reset the primary key sequence
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Positions', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Candidates', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('ElectionEvent', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('VoteTransactions', RESEED, 0)");

            TempData["successMessage"] = "Reset successful!";
            return RedirectToAction("Index", "ElectionEvent");

        }
    }
}
