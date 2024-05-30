using System.ComponentModel.DataAnnotations;

namespace ProgPoe_MVC_AgriEnergyConnect.ViewModels
{
    public class RegisterViewModel
    {
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "The email address is required.")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the password confirmation.
        /// </summary>
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 