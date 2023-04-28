using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OVSystemProject.ViewModels
{
    public class CandidateViewModel
    {
        [Key]
        public int CandidateId { get; set; }
        [Required]
        [DisplayName("First Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only")]
        public string? MiddleName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only")]
        public string LastName { get; set; }
        [DisplayName("Name Extension/Suffix")]
        public string? NameExtension { get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        [DisplayName("Civil Status")]
        public string CivilStatus { get; set; }
        [Required]
        public string Citizenship { get; set; }

        public IFormFile? Photo { get; set; }
        [ForeignKey("Positions")]
        public int PositionId { get; set; }
        [Required]
        public string Party { get; set; }
    }
}
