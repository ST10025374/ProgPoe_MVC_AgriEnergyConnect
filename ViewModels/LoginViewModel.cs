using System.ComponentModel.DataAnnotations;

namespace ProgPoe_MVC_AgriEnergyConnect.ViewModels
{
    public class LoginViewModel
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
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 