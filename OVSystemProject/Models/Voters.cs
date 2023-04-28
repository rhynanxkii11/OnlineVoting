using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OVSystemProject.Models
{
    public class Voters
    {
        [Key]
        public int VoterId { get; set; }
        [ForeignKey("ApplicationUsers")]
        public string UserId { get; set; }
        public string PBMunicipality { get; set; }

        public string PBProvince { get; set; }

        public string CivilStatus { get; set; }
        public string Citizenship { get; set; }
        public string Occupation { get; set; }

        public virtual ApplicationUsers applicationUser { get; set; }

    }
}
