using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProgPoe_MVC_AgriEnergyConnect.Models;

namespace ProgPoe_MVC_AgriEnergyConnect.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Gets or sets the DbSet of Products.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the DbSet of Farmers.
        /// </summary>
        public DbSet<Farmer> Farmers { get; set; }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 