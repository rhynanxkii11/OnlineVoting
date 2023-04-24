using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace OVSystemProject.Controllers.Admin
{
    //[Authorize(Roles = "Admin")]
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
    }
}
