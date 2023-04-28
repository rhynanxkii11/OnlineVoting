using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OVSystemProject.Models
{
    public class ApplicationUsers : IdentityUser
    {
        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? MiddleName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string LastName { get; set; }
        [StringLength(5)]
        [Column(TypeName = "char(5)")]
        public string? NameExtension { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        [StringLength(1)]
        [Column(TypeName = "char(1)")]
        public string Sex { get; set; }
        public string Photo { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RegisteredDate { get; set; }


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
