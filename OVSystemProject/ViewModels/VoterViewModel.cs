using OVSystemProject.Models;

namespace OVSystemProject.ViewModels
{
    public class VoterViewModel
    {
        public ApplicationUsers User { get; set; }
        public Voters Voter { get; set; }
        public Addresses Address { get; set; }
    }
}
