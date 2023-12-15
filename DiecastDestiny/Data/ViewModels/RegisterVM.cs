using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DiecastDestiny.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required!")]
        public string FullName { get; set; }

        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="Email address is required!")]
        public string EmailAddress { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%#*?&])[A-Za-z\d@$!%#*?&]{8,}$", 
            ErrorMessage = "Passwords must be at least 8 characters and contain at least one of each of the following: upper case (A-Z), " +
            "lower case (a-z), number (0-9) and special character (e.g. @$!%#*?&)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage ="Password confirmation is required!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Passwords do not match!")]
        public string ConfirmPassword { get; set; }
    }
}
