using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using OVSystemProject.Data;
using OVSystemProject.ViewModels;

namespace OVSystemProject.Controllers
{
    public class ResultController : Controller
    {
        private readonly OnlineVotingDbContext _context;

        public ResultController(OnlineVotingDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var results = await _context.VoteTransactions
        //        .GroupBy(v => v.CandidateId)
        //        .Select(g => new ResultViewModel
        //        {
        //            CandidateId = g.Key,
        //            CandidateName = g.FirstOrDefault().Candidates.FullName,
        //            TotalVotes = g.Count()
        //        })
        //        .ToListAsync();

        //    return View(results);
        //}
        private List<ResultViewModel> CalculateVoteTallies()
        {
            var voteTallies = _context.VoteTransactions
                .Include(v => v.Candidates)
                .ThenInclude(c => c.Positions)
                .GroupBy(v => new { v.CandidateId, v.Candidates.PositionId })
                .Select(g => new ResultViewModel
                {
                    CandidateId = g.Key.CandidateId,
                    CandidateName = g.First().Candidates.FullName,
                    Position = g.First().Candidates.Positions.PositionName,
                    TotalVotes = g.Count()
                })
                .ToList();

            return voteTallies;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var voteTallies = CalculateVoteTallies();
            var viewModel = new ResultsViewModel
            {
                VoteTallies = voteTallies
            };
            return View(viewModel);
        }
    }
}
