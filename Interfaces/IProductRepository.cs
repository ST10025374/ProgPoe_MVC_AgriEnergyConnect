using ProgPoe_MVC_AgriEnergyConnect.Data.Enum;
using ProgPoe_MVC_AgriEnergyConnect.Models;

namespace ProgPoe_MVC_AgriEnergyConnect.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetAll();

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProductById(int id);

        /// <summary>
        /// Get product by id asynchronously without tracking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product?> GetProductByIdAsyncNoTracking(int id);

        /// <summary>
        /// Filtering Logic
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetFilteredProducts(DateTime startDate, DateTime endDate, string category);

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductCategories>> GetAllCategories();

        /// <summary>
        /// Get products by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductByName(string name);

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        bool AddProduct(Product product);

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        bool UpdateProduct(Product product);

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteProduct(Product product);

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        bool Save();
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 