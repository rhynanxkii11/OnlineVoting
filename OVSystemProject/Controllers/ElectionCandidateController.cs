using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OVSystemProject.Data;

namespace OVSystemProject.Controllers
{
    [Authorize]
    public class ElectionCandidateController : Controller
    {
        private readonly OnlineVotingDbContext _context;

        public ElectionCandidateController(OnlineVotingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            //IEnumerable<Candidates> candidates = await _context.Candidates.ToListAsync();
            //var candidates = await _context.Candidates.ToListAsync();

            //List<Positions> positions = await _context.Positions.ToListAsync();
            //ViewBag.CandidatePositions = positions;

            var positions = await _context.Positions.Include(p => p.Candidates).ToListAsync();

            return View(positions);
        }
    }
}
