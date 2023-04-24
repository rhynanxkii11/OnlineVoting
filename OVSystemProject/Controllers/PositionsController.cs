using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OVSystemProject.Data;
using OVSystemProject.Models;

namespace OVSystemProject.Controllers
{
    public class PositionsController : Controller
    {
        private readonly OnlineVotingDbContext _context;

        public PositionsController(OnlineVotingDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Positions> positions = await _context.Positions.ToListAsync();
            return View(positions);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Positions position)
        {
            if (ModelState.IsValid)
            {
                await _context.Positions.AddAsync(position);

                _context.SaveChangesAsync();
                TempData["successMessage"] = "New positons added successfuly!";
                return RedirectToAction("Index");
            }
            return View(position);
        }
    }
}
