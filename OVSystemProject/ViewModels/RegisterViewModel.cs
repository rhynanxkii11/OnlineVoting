using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OVSystemProject.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(50)]
        [Unicode(false)]
        [DisplayName("First Name")]
        [System.ComponentModel.DataAnnotations.Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        [DisplayName("Middle Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only")]
        public string? MiddleName { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        [DisplayName("Last Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only")]
        [System.ComponentModel.DataAnnotations.Required]
        public string LastName { get; set; }

        [StringLength(5)]
        [Column(TypeName = "char(5)")]
        [DisplayName("Name Extension")]
        public string? NameExtension { get; set; }

        [DisplayName("Date of Birth")]
        [System.ComponentModel.DataAnnotations.Required]
        public DateTime DateOfBirth { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public int Age { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(1)]
        [Column(TypeName = "char(1)")]
        public string Sex { get; set; }

        [Required]
        [DisplayName("Municipality")]
        public string PBMunicipality { get; set; }
        [Required]
        [DisplayName("Province")]
        public string PBProvince { get; set; }
        [Required]
        [DisplayName("CivilStatus")]
        public string CivilStatus { get; set; }
        [Required]

        public string Citizenship { get; set; }
        [Required]
        public string Occupation { get; set; }
        [DisplayName("House No/Street")]
        [Required]
        public string AddHouseNoStreet { get; set; }
        [Required]
        [DisplayName("Barangay")]
        public string AddBarangay { get; set; }
        [Required]
        [DisplayName("Municipality")]
        public string AddMunicipality { get; set; }
        [Required]
        [DisplayName("Province")]
        public string AddProvince { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public IFormFile Photo { get; set; }

        //public IFormFile ImageFile { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RegisteredDate { get; set; }

        //[System.ComponentModel.DataAnnotations.Required]
        //public string Role { get; set; }
        [DisplayName("Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
