using Microsoft.AspNetCore.Identity;

namespace ProgPoe_MVC_AgriEnergyConnect.Models
{
    public class AppUser : IdentityUser
    {

        /// <summary>
        /// Store User First Name
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Store User Last Name
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Store User Profile Image
        /// </summary>
        public string? ProfileImage { get; set; }

        /// <summary>
        /// Store User City
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Store User State
        /// </summary>
        public string? State { get; set; }

        /// <summary>
        /// The collection of products associated with the user.
        /// </summary>
        public ICollection<Product>? Products { get; set; }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 