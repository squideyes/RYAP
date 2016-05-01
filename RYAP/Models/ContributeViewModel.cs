using System.ComponentModel.DataAnnotations;

namespace RYAP.Website.Models
{
    public class ContributeViewModel
    {
        [Required(ErrorMessage = "A valid email must be supplied.")]
        [EmailAddress(ErrorMessage ="The email address is invalid.")]
        [StringLength(50, MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5,
            ErrorMessage = "A first and last name must be supplied!")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "From")]
        [StringLength(50, MinimumLength = 10,
            ErrorMessage = "A location must be supplied (i.e. New York, NY).")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Setup")]
        [StringLength(100, MinimumLength = 5)]
        public string Question { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Answer { get; set; }
    }
}