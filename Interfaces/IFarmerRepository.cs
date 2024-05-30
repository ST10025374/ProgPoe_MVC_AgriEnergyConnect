using ProgPoe_MVC_AgriEnergyConnect.Models;

namespace ProgPoe_MVC_AgriEnergyConnect.Interfaces
{
    public interface IFarmerRepository
    {
        /// <summary>
        /// Retrieves all farmers.
        /// </summary>
        /// <returns>An enumerable collection of farmers.</returns>
        Task<IEnumerable<Farmer>> GetAll();

        /// <summary>
        /// Retrieves a farmer by their ID.
        /// </summary>
        /// <param name="id">The ID of the farmer.</param>
        /// <returns>The farmer with the specified ID.</returns>
        Task<Farmer> GetFarmerById(int id);

        /// <summary>
        /// Retrieves a farmer by their ID without tracking changes.
        /// </summary>
        /// <param name="id">The ID of the farmer.</param>
        /// <returns>The farmer with the specified ID.</returns>
        Task<Farmer> GetFarmerByIdAsyncNoTracking(int id);

        /// <summary>
        /// Retrieves farmers by their name.
        /// </summary>
        /// <param name="name">The name of the farmer.</param>
        /// <returns>An enumerable collection of farmers with the specified name.</returns>
        Task<IEnumerable<Farmer>> GetProductByName(string name);

        /// <summary>
        /// Adds a new farmer.
        /// </summary>
        /// <param name="farmer">The farmer to add.</param>
        /// <returns>True if the farmer was added successfully, otherwise false.</returns>
        bool AddFarmer(Farmer farmer);

        /// <summary>
        /// Updates an existing farmer.
        /// </summary>
        /// <param name="farmer">The farmer to update.</param>
        /// <returns>True if the farmer was updated successfully, otherwise false.</returns>
        bool UpdateFarmer(Farmer farmer);

        /// <summary>
        /// Deletes a farmer.
        /// </summary>
        /// <param name="farmer">The farmer to delete.</param>
        /// <returns>True if the farmer was deleted successfully, otherwise false.</returns>
        bool DeleteFarmer(Farmer farmer);

        /// <summary>
        /// Saves changes to the data store.
        /// </summary>
        /// <returns>True if the changes were saved successfully, otherwise false.</returns>
        bool Save();
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 