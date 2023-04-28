using OVSystemProject.Models;

namespace OVSystemProject.ViewModels
{
    public class CandidatesViewModel
    {
        public CandidateViewModel CandidateViewModel { get; set; }
        public IEnumerable<Positions>? Positions { get; set; }
    }
}
