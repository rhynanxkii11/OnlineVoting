using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OVSystemProject.Data;
using OVSystemProject.Models;
using System.Data;

namespace OVSystemProject.Controllers
{
    [Authorize(Roles = "Admin")]
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
            bool positionExists = await _context.Positions.AnyAsync(p => p.PositionName == position.PositionName);

            if (positionExists)
            {
                TempData["errorMessage"] = $"The {position.PositionName} is already exists!";
                return View();
            }
            if (ModelState.IsValid)
            {
                await _context.Positions.AddAsync(position);

                await _context.SaveChangesAsync();
                TempData["successMessage"] = "New positon has been added successfully!";
                return RedirectToAction("Index");
            }
            return View(position);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["errorMessage"] = "Id is not found!";
                return View();
            }
            var position = await _context.Positions.FindAsync(id);

            if (position == null)
            {
                TempData["errorMessage"] = "Position is not found!";
                return View();
            }
            return View(position);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Positions position)
        {
            if (ModelState.IsValid)
            {
                var existingPosition = await _context.Positions.FindAsync(id);

                if(existingPosition.PositionName == position.PositionName)
                {
                    TempData["errorMessage"] = "No changes made!";
                    return RedirectToAction("Index");
                }
                existingPosition.PositionName = position.PositionName;

                await _context.SaveChangesAsync();
                TempData["successMessage"] = "Position name has been updated successfully!";
                return RedirectToAction("Index");
            }
            return View(position);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["errorMessage"] = "Id is not found!";
                return View();
            }
            var position = await _context.Positions.FindAsync(id);

            if (position == null)
            {
                TempData["errorMessage"] = "Position is not found!";
                return View();
            }
            return View(position);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position == null)
            {
                TempData["errorMessage"] = "Id is not found!";
                return View();
            }
            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
            TempData["successMessage"] = "Position has been deleted successfully!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null ||id == 0)
            {
                TempData["errorMessage"] = "Id is not found!";
                return View();
            }

            var position = await _context.Positions.Include(p => p.Candidates).SingleOrDefaultAsync(p => p.PositionId == id);

            if (position == null)
            {
                TempData["errorMessage"] = "Position is not found!";
                return View();
            }
            return View(position);
        }
    }
}
