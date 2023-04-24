using System.ComponentModel.DataAnnotations;

namespace OVSystemProject.Models
{
    public class Positions
    {
        [Key]
        public int PositionId { get; set; }
        public string PositionName { get; set; }
    }
}
