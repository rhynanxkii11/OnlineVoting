using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OVSystemProject.Data;
using OVSystemProject.Models;
using OVSystemProject.ViewModels;

namespace OVSystemProject.Controllers
{
    public class VoteController : Controller
    {
        private readonly OnlineVotingDbContext _context;
        private readonly UserManager<ApplicationUsers> _userManager;

        public VoteController(OnlineVotingDbContext context, UserManager<ApplicationUsers> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //var electionEvent = _context.ElectionEvent.ToList();
            ElectionEvent election = _context.ElectionEvent.SingleOrDefault();

            if (election == null)
            {
                TempData["errorMessage"] = "No election event.";
                return RedirectToAction("Index", "Home");
            }
            if (election.StartDate > DateTime.Now && election.EndDate < DateTime.Now)
            {
                TempData["errorMessage"] = $"Election has not started yet. Please comeback on {election.StartDate}";
                return RedirectToAction("Index", "Home");
            }
            var currentUserId = _userManager.GetUserId(User);
            var hasVoted = _context.VoteTransactions.Any(vt => vt.VoterId == currentUserId);

            if (hasVoted)
            {
                TempData["errorMessage"] = "You have already voted";
                return RedirectToAction("Index", "Home");
            }

            var positions = _context.Positions.Include(p => p.Candidates).ToList();
            var transaction = new TransactionsViewModel
            {
                Positions = positions,
                //SelectedCandidate = new List<int>()
            };
            return View(transaction);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public async Task<IActionResult> SubmitForm(List<int> selectedCandidates)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = _userManager.GetUserId(User);

                foreach (var candidateId in selectedCandidates)
                {
                    if (candidateId == 0)
                    {
                        continue;
                    }
                    var voteTransaction = new VoteTransactions
                    {
                        VoterId = currentUserId,
                        CandidateId = candidateId
                    };

                    await _context.VoteTransactions.AddAsync(voteTransaction);
                }
                await _context.SaveChangesAsync();
                TempData["successMessage"] = "Your vote has been submitted successfully!";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
