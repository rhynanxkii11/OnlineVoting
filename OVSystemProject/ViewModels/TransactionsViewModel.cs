using OVSystemProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OVSystemProject.ViewModels
{
    public class TransactionsViewModel
    {
        public List<Positions> Positions { get; set; }
        //[NotMapped]
        //public List<int> SelectedCandidates { get; set; }
    }
}
