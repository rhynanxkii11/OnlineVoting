using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace OVSystemProject.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class ApplicationRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationRolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        //list of Roles
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                TempData["errorMessage"] = "Id is not found!";
                return View();
            }
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                TempData["errorMessage"] = "Role is not found!";
                return View();
            }
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string? id, IdentityRole name)
        {
            if (id == null)
            {
                TempData["errorMessage"] = "Id is not found!";
                return View();
            }
            var role = await _roleManager.FindByIdAsync(id);
            if(role.Name == name.Name)
            {
                TempData["errorMessage"] = "No changes made";
                return RedirectToAction("Index");
            }
             var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                TempData["successMessage"] = "Role has been updated successfully!";
                return View();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(role); 
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                TempData["errorMessage"] = "Id is not found!";
                return View();
            }
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                TempData["errorMessage"] = "Role is not found!";
                return View();
            }
            return View(role);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string? id)
        {
            if (id == null)
            {
                TempData["errorMessage"] = "Id is not found!";
                return View();
            }
            var role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    TempData["successMessage"] = "Role has been updated successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return NotFound();
        }
    }
}
