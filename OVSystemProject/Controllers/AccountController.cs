using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OVSystemProject.Data;
using OVSystemProject.Models;
using OVSystemProject.ViewModels;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace OVSystemProject.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly OnlineVotingDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, OnlineVotingDbContext context, IWebHostEnvironment webHostEnvironment) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string photoFile = string.Empty;

                if(model.Photo != null)
                {
                    photoFile = UploadedPhoto(model.Photo);
                }
                var user = new ApplicationUsers
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    NameExtension = model.NameExtension,
                    DateOfBirth = model.DateOfBirth,
                    Age = model.Age,
                    Sex = model.Sex,
                    Photo = photoFile,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var voter = new Voters
                    {
                        UserId = user.Id,
                        PBMunicipality = model.PBMunicipality,
                        PBProvince = model.PBProvince,
                        CivilStatus = model.CivilStatus,
                        Citizenship = model.Citizenship,
                        Occupation = model.Occupation
                    };
                    await _context.Voters.AddAsync(voter);
                    await _context.SaveChangesAsync();
                    var address = new Addresses
                    {
                        VoterId = voter.VoterId,
                        AddHouseNoStreet = model.AddHouseNoStreet,
                        AddBarangay = model.AddBarangay,
                        AddMunicipality = model.AddMunicipality,
                        AddProvince = model.AddProvince
                    };
                    
                    await _context.Addresses.AddAsync(address);
                    await _context.SaveChangesAsync();

                    await _userManager.AddToRoleAsync(user, "Voter");

                    TempData["successMessage"] = "Your registration has been successfull!";
                    return RedirectToAction("Login", "Voter");
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    
                    var user = await _signInManager.UserManager.FindByNameAsync(model.Email);
                    var roles = await _signInManager.UserManager.GetRolesAsync(user);
                    if (roles.Contains("Admin"))
                    {
                        TempData["successMessage"] = "Logged in successfully!";
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else if (roles.Contains("Voter"))
                    {
                        TempData["successMessage"] = "Logged in successfully!";
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid user login credentials.");
            }
            return View(model);
        }
        private string UploadedPhoto(IFormFile photo)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img/user");
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
