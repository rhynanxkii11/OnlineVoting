using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OVSystemProject.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUsers applicationUser { get; set; }

    }
}
