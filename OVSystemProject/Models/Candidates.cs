using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace OVSystemProject.Models
{
    public class Candidates
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
        [Required]
        public string Photo { get; set; }
        [ForeignKey("Positions")]
        public int PositionId { get; set; }
        [Required]
        public string Party { get; set; }
        public DateTime RegisteredDate { get; set; } = DateTime.Now;

        public virtual Positions Positions { get; set; }

        //public string PositionName => Positions == null ? "" : Positions.PositionName;
        [NotMapped]
        public string FullName
        {
            get
            {
                if (MiddleName != null)
                {
                    return $"{FirstName} {MiddleName} {LastName}";
                }
                if (NameExtension != null)
                {
                    return $"{FirstName} {LastName} {NameExtension}";
                }
                if (MiddleName != null && NameExtension != null)
                {
                    return $"{FirstName} {MiddleName} {LastName} {NameExtension}";
                }
                return $"{FirstName} {LastName}";
            }
        }
    }
}
