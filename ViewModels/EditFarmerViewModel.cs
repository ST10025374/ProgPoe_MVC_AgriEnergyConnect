using ProgPoe_MVC_AgriEnergyConnect.Models;

namespace ProgPoe_MVC_AgriEnergyConnect.ViewModels
{
    public class EditFarmerViewModel
    {
        /// <summary>
        /// Gets or sets the ID of the farmer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the farmer.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the farmer.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the location of the farmer.
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the farmer.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the city of the farmer.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the province of the farmer.
        /// </summary>
        public string? Province { get; set; }

        /// <summary>
        /// Gets or sets the profile image of the farmer.
        /// </summary>
        public IFormFile ProfileImage { get; set; }

        /// <summary>
        /// Gets or sets the URL of the farmer.
        /// </summary>
        public string? URL { get; set; }

        /// <summary>
        /// Gets or sets the ID of the app user associated with the farmer.
        /// </summary>
        public string? AppUserId { get; set; }

        /// <summary>
        /// Gets or sets the app user associated with the farmer.
        /// </summary>
        public AppUser? AppUser { get; set; }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 