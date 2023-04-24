using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OVSystemProject.Models
{
    public class Addresses
    {
        [Key]
        public int AddressId { get; set; }
        [ForeignKey("Voter")]
        public int VoterId { get; set; }
        public string AddHouseNoStreet { get; set; }
        public string AddBarangay { get; set; }
        public string AddMunicipality { get; set; }
        public string AddProvince { get; set; }
        public virtual Voters voter { get; set; }
    }
}
