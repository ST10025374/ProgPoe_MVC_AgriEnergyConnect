    using Microsoft.EntityFrameworkCore;
using ProgPoe_MVC_AgriEnergyConnect.Data;
using ProgPoe_MVC_AgriEnergyConnect.Interfaces;
using ProgPoe_MVC_AgriEnergyConnect.Models;

namespace ProgPoe_MVC_AgriEnergyConnect.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        //---------------------------------------------------------------------//
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Adds a product to the repository.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <returns>True if the product was successfully added, otherwise false.</returns>
        public bool AddProduct(Product product)
        {
            _context.Add(product);
            return Save();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Deletes a product from the repository.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>True if the product was successfully deleted, otherwise false.</returns>
        public bool DeleteProduct(Product product)
        {
            _context.Remove(product);
            return Save();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Gets all products from the repository.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the collection of products.</returns>
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Gets a product by its ID from the repository.
        /// </summary>
        /// <param name="id">The ID of the product to get.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the product.</returns>
        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(i => i.ProductId == id);
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Gets a product by its ID from the repository without tracking changes.
        /// </summary>
        /// <param name="id">The ID of the product to get.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the product.</returns>
        public async Task<Product?> GetProductByIdAsyncNoTracking(int id)
        {
            return await _context.Products.Include(i => i.AppUser).AsNoTracking().FirstOrDefaultAsync(i => i.ProductId == id);
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Gets products by their name from the repository.
        /// </summary>
        /// <param name="name">The name of the products to get.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the collection of products.</returns>
        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _context.Products.Where(n => n.Name.Contains(name)).ToListAsync();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Saves changes made to the repository.
        /// </summary>
        /// <returns>True if the changes were successfully saved, otherwise false.</returns>
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false; 
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Updates a product in the repository.
        /// </summary>
        /// <param name="product">The product to update.</param>
        /// <returns>True if the product was successfully updated, otherwise false.</returns>
        public bool UpdateProduct(Product product)
        {
            _context.Update(product);
            return Save();
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 