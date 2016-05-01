using System.ComponentModel.DataAnnotations;

namespace RYAP.Models
{
    public class ContributeViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50, MinimumLength = 6,
            ErrorMessage = "A valid email address must be supplied!")]
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