using Microsoft.AspNetCore.Mvc;
using ProgPoe_MVC_AgriEnergyConnect.Interfaces;
using ProgPoe_MVC_AgriEnergyConnect.Models;
using ProgPoe_MVC_AgriEnergyConnect.ViewModels;
using System.Security.Claims;

namespace ProgPoe_MVC_AgriEnergyConnect.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IPhotoService _photoService;

        //---------------------------------------------------------------------//
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public ProductController(IProductRepository productRepository, IPhotoService photoService)
        {
            _productRepository = productRepository;
            _photoService = photoService;
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Retrieves all products and returns the view with the products.
        /// </summary>
        /// <returns>The view with the products.</returns>
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productRepository.GetAll();
            return View(products);
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Retrieves View for creating a new product.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
               var result = await _photoService.AddPhotoAsync(productVM.Image);  

               var product = new Product
               {
                   Name = productVM.Name,
                   Description = productVM.Description,
                   Price = productVM.Price,
                   ProductDate = productVM.ProductDate,
                   Categories = productVM.Categories,
                   ProductImage = result.Url.ToString(),
                   AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
               };
                _productRepository.AddProduct(product);
                return RedirectToAction("Index");
            }  
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(productVM);
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Returns the view for editing a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null) return View("Error");
            var productVM = new EditProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                URL = product.ProductImage,
                AppUserId = product.AppUserId,
                AppUser = product.AppUser,
                ProductDate = product.ProductDate,
                Categories = product.Categories
            };

            return View(productVM);
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Edit product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productVM"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditProductViewModel productVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit product");
                return View("Edit", productVM);
            }

            var userProduct = await _productRepository.GetProductByIdAsyncNoTracking(id);

            if (userProduct == null)
            {
                return View("Error");
            }

            var photoResult = await _photoService.AddPhotoAsync(productVM.Image);

            if (photoResult.Error != null)
            {
                ModelState.AddModelError("Image", "Photo upload failed");
                return View(productVM);
            }

            if (!string.IsNullOrEmpty(userProduct.ProductImage))
            {
                _ = _photoService.DeletePhotoAsync(userProduct.ProductImage);
            }

            var product = new Product
            {
                ProductId = id,
                Name = productVM.Name,
                Description = productVM.Description,
                Price = productVM.Price,
                ProductDate = productVM.ProductDate,
                Categories = productVM.Categories,
                ProductImage = photoResult.Url.ToString(),
                AppUserId = productVM.AppUserId,
                AppUser = productVM.AppUser
            };

            _productRepository.UpdateProduct(product);

            return RedirectToAction("Index");
        }

        ////---------------------------------------------------------------------//
        ///// <summary>
        ///// Returns the view for deleting a product
        ///// </summary>
        ///// <param name = "id" ></ param >
        ///// < returns ></ returns >
        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var productDetails = await _productRepository.GetProductById(id);
        //    if (productDetails == null) return View("Error");
        //    return View(productDetails);
        //}

        //---------------------------------------------------------------------//
        /// <summary>
        /// Deletes a product
        /// </summary>
        /// <param name = "id" ></ param >
        /// < returns ></ returns >
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productDetails = await _productRepository.GetProductById(id);

            if (productDetails == null)
            {
                return View("Error");
            }

            if (!string.IsNullOrEmpty(productDetails.ProductImage))
            {
                _ = _photoService.DeletePhotoAsync(productDetails.ProductImage);
            }

            _productRepository.DeleteProduct(productDetails);
            return RedirectToAction("Index");
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 