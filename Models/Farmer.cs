using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgPoe_MVC_AgriEnergyConnect.Models
{
    public class Farmer
    {
        /// <summary>
        /// Gets or sets the ID of the farmer profile.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the farmer.
        /// </summary>
        [Required(ErrorMessage = "First name is required.")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the farmer.
        /// </summary>
        [Required(ErrorMessage = "Last name is required.")]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the location of the farmer.
        /// </summary>
        [Required(ErrorMessage = "Location is required.")]
        public string? Location { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the farmer.
        /// </summary>
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone number is required.")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the city of the farmer.
        /// </summary>
        [Required(ErrorMessage = "City is required.")]
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the province of the farmer.
        /// </summary>
        [Required(ErrorMessage = "Province is required.")]
        public string? Province { get; set; }

        /// <summary>
        /// Gets or sets the profile image of the farmer.
        /// </summary>
        [Required(ErrorMessage = "Profile image is required.")]
        public string? ProfileImage { get; set; }

        /// <summary>
        /// Gets or sets the ID of the associated app user.
        /// </summary>
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }

        /// <summary>
        /// Gets or sets the associated app user.
        /// </summary>
        public AppUser? AppUser { get; set; }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 