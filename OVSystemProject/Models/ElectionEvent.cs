using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OVSystemProject.Models
{
    public class ElectionEvent
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

    }
}
