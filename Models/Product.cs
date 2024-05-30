using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProgPoe_MVC_AgriEnergyConnect.Data.Enum;

namespace ProgPoe_MVC_AgriEnergyConnect.Models
{
    public class Product
    {
        /// <summary>
        /// Stores the unique identifier for the product
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// Stores the name of the product
        /// </summary>
        [Required(ErrorMessage = "Product name is required.")]
        public string? Name { get; set; }

        /// <summary>
        /// Stores the description of the product
        /// </summary>
        [Required(ErrorMessage = "Product description is required.")]
        public string? Description { get; set; }

        /// <summary>
        /// Stores the price of the product
        /// </summary>
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Product price is required.")]
        public double? Price { get; set; }

        /// <summary>
        /// Stores product Image
        /// </summary>
        [Required(ErrorMessage = "Product image is required.")]
        public string? ProductImage { get; set; }

        /// <summary>
        /// Stores the date the product was added
        /// </summary>
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Product date is required.")]
        public DateTime ProductDate { get; set; }

        /// <summary>
        /// Stores the category of the product
        /// </summary>
        [Required(ErrorMessage = "Product category is required.")]
        public ProductCategories Categories { get; set; }

        /// <summary>
        /// Stores the user ID of the user who added the product
        /// </summary>
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }

        /// <summary>
        /// Stores the user who added the product
        /// </summary>
        public AppUser? AppUser { get; set; }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 