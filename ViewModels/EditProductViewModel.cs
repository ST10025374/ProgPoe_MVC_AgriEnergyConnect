﻿using ProgPoe_MVC_AgriEnergyConnect.Data.Enum;
using ProgPoe_MVC_AgriEnergyConnect.Models;

namespace ProgPoe_MVC_AgriEnergyConnect.ViewModels
{
    public class EditProductViewModel
    {
        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// Gets or sets the URL of the product.
        /// </summary>
        public string? URL { get; set; }

        /// <summary>
        /// Gets or sets the image of the product.
        /// </summary>
        public IFormFile Image { get; set; }

        /// <summary>
        /// Gets or sets the date of the product.
        /// </summary>
        public DateTime ProductDate { get; set; }

        /// <summary>
        /// Gets or sets the categories of the product.
        /// </summary>
        public ProductCategories Categories { get; set; }

        /// <summary>
        /// Gets or sets the ID of the app user associated with the product.
        /// </summary>
        public string? AppUserId { get; set; }

        /// <summary>
        /// Gets or sets the app user associated with the product.
        /// </summary>
        public AppUser? AppUser { get; set; }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 