using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OVSystemProject.Data;
using OVSystemProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace OVSystemProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VotersController : Controller
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly OnlineVotingDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public VotersController(UserManager<ApplicationUsers> userManager, RoleManager<IdentityRole> roleManager, OnlineVotingDbContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            //var Users = _userManager.Users;
            //var voterRole = await (from user in _context.Users
            //                       join userRole in _context.UserRoles
            //                       on user.Id equals userRole.UserId
            //                       join role in _context.Roles
            //                       on userRole.RoleId equals role.Id
            //                       where role.Name == "Voter"
            //                       select user).ToListAsync();
            //return View(voterRole);
            try
            {
                var voters = await _userManager.GetUsersInRoleAsync("Voter");
                return View(voters);
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message.ToString();
                return View();
            }
        }
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                if (id == null)
                {
                    TempData["errorMessage"] = "Id is not found!";
                    return View();
                }

                //var voter = await _context.Voters.Include(v => v.Addresses).FirstOrDefaultAsync(v => v.UserId == user.Id);

                return View(user);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message.ToString();
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                if (id == null)
                {
                    TempData["errorMessage"] = "Id is not found!";
                    return View();
                }

                //var voter = await _context.Voters.Include(v => v.Addresses).FirstOrDefaultAsync(v => v.UserId == user.Id);

                return View(user);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message.ToString();
                return View();
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if(user != null)
            {
                var result = await _userManager.DeleteAsync(user);

                if(result.Succeeded)
                {
                    var voter = _context.Voters.FirstOrDefault(v => v.UserId == id);

                    if(voter != null)
                    {
                        var address = _context.Addresses.FirstOrDefault(a => a.VoterId == voter.VoterId);

                        if(address != null)
                        {
                            _context.Addresses.Remove(address);
                        }
                        string temp = user.Photo;

                        _context.Voters.Remove(voter);

                        if (temp != null)
                        {
                            DeletePhoto(temp, "user");
                        }
                    }
                    await _context.SaveChangesAsync();
                    TempData["successMessage"] = "Voter has been deleted successfully!";
                    return RedirectToAction("Index");
                }
            }
            return BadRequest();
        }
        public IActionResult DeletePhoto(string fileName, string person)
        {
            try
            {
                string? fullPath = null;

                // Combine the web root path with the file path
                if (person == "candidate")
                {
                    fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/candidate", fileName);
                }
                else if (person == "user")
                {
                    fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/user", fileName);
                }

                // Delete the file
                System.IO.File.Delete(fullPath);

                return Ok("File deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting file: {ex.Message}");
            }
        }
    }
}
