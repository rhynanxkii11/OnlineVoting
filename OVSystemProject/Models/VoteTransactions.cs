using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OVSystemProject.Models
{
    public class VoteTransactions
    {
        [Key]
        public int VoteTransactionId { get; set; }
        [ForeignKey("ApplicationUsers")]
        public string VoterId { get; set; }
        [ForeignKey("Candidates")]
        public int CandidateId { get; set; }
        public DateTime VotedDate { get; set; } = DateTime.UtcNow;
        public ApplicationUsers ApplicationUsers { get; set; }
        public Candidates Candidates { get; set; }
    }
}
