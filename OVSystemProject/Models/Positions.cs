using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OVSystemProject.Models
{
    public class Positions
    {
        [Key]
        public int PositionId { get; set; }
        [Required]
        [DisplayName("Position Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only")]
        public string PositionName { get; set; }

        public ICollection<Candidates>? Candidates { get; set; }
    }
}
