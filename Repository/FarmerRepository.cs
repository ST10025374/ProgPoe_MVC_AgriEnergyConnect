using Microsoft.EntityFrameworkCore;
using ProgPoe_MVC_AgriEnergyConnect.Data;
using ProgPoe_MVC_AgriEnergyConnect.Models;
using ProgPoe_MVC_AgriEnergyConnect.Interfaces;

namespace ProgPoe_MVC_AgriEnergyConnect.Repository
{
    public class FarmerRepository : IFarmerRepository
    {
        private readonly ApplicationDbContext _context;

        //---------------------------------------------------------------------//
        /// <summary>
        /// Initializes a new instance of the <see cref="FarmerRepository"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public FarmerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Adds a new farmer to the database.
        /// </summary>
        /// <param name="farmer">The farmer to add.</param>
        /// <returns>True if the farmer was added successfully, otherwise false.</returns>
        public bool AddFarmer(Farmer farmer)
        {
            _context.Add(farmer);
            return Save();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Retrieves all farmers from the database.
        /// </summary>
        /// <returns>A collection of all farmers.</returns>
        public async Task<IEnumerable<Farmer>> GetAll()
        {
            return await _context.Farmers.ToListAsync();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Retrieves a farmer by their ID from the database.
        /// </summary>
        /// <param name="id">The ID of the farmer to retrieve.</param>
        /// <returns>The farmer with the specified ID, or null if not found.</returns>
        public async Task<Farmer> GetFarmerById(int id)
        {
            return await _context.Farmers.FirstOrDefaultAsync(f => f.Id == id);
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Retrieves a farmer's ID by their AppUserId from the database.
        /// </summary>
        /// <param name="appUserId">The AppUserId of the farmer to retrieve.</param>
        /// <returns>The farmer's ID with the specified AppUserId, or null if not found.</returns>
        public async Task<int?> GetFarmerIdByAppUserId(string appUserId)
        {
            var farmerId = await _context.Farmers
                .Where(f => f.AppUserId == appUserId)
                .Select(f => f.Id) 
                .FirstOrDefaultAsync();

            return farmerId;
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Retrieves a farmer by their ID from the database without tracking changes.
        /// </summary>
        /// <param name="id">The ID of the farmer to retrieve.</param>
        /// <returns>The farmer with the specified ID, or null if not found.</returns>
        public async Task<Farmer> GetFarmerByIdAsyncNoTracking(int id)
        {
            return await _context.Farmers.Include(i => i.AppUser).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Retrieves farmers by their first name from the database.
        /// </summary>
        /// <param name="name">The first name to search for.</param>
        /// <returns>A collection of farmers with matching first names.</returns>
        public async Task<IEnumerable<Farmer>> GetFarmerByName(string name)
        {
            return await _context.Farmers.Where(n => n.FirstName.Contains(name)).ToListAsync();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Saves changes made to the database.
        /// </summary>
        /// <returns>True if changes were saved successfully, otherwise false.</returns>
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Updates a farmer in the database.
        /// </summary>
        /// <param name="farmer">The farmer to update.</param>
        /// <returns>True if the farmer was updated successfully, otherwise false.</returns>
        public bool UpdateFarmer(Farmer farmer)
        {
            _context.Update(farmer);
            return Save();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Deletes a farmer from the database.
        /// </summary>
        /// <param name="farmer">The farmer to delete.</param>
        /// <returns>True if the farmer was deleted successfully, otherwise false.</returns>
        public bool DeleteFarmer(Farmer farmer)
        {
            _context.Remove(farmer);
            return Save();
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 