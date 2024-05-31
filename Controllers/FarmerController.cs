using Microsoft.AspNetCore.Mvc;
using ProgPoe_MVC_AgriEnergyConnect.Interfaces;
using ProgPoe_MVC_AgriEnergyConnect.Models;
using ProgPoe_MVC_AgriEnergyConnect.Repository;
using ProgPoe_MVC_AgriEnergyConnect.ViewModels;
using System.Security.Claims;

namespace ProgPoe_MVC_AgriEnergyConnect.Controllers
{
    public class FarmerController : Controller
    {
        private readonly IFarmerRepository _farmerRepository;
        private readonly IPhotoService _photoService;

        //---------------------------------------------------------------------//
        /// <summary>
        /// Initializes a new instance of the <see cref="FarmerController"/> class.
        /// </summary>
        /// <param name="farmerRepository">The farmer repository.</param>
        /// <param name="photoService">The photo service.</param>
        public FarmerController(IFarmerRepository farmerRepository, IPhotoService photoService)
        {
            _farmerRepository = farmerRepository;
            _photoService = photoService;
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Retrieves all farmers and returns the view with the farmers.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            IEnumerable<Farmer> farmers = await _farmerRepository.GetAll();
            return View(farmers);
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Retrieves View for creating a new farmer.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Creates a new farmer.
        /// </summary>
        /// <param name="farmer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateFarmerViewModel farmerVM)
        {
            //var valid = _farmerRepository.GetFarmerIdByAppUserId(User.FindFirstValue(ClaimTypes.NameIdentifier));

            //if (valid != null)
            //{
            //    ModelState.AddModelError("", "You already have a farmer profile");
            //    return View(farmerVM);
            //}

            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(farmerVM.ProfileImage);

                var farmer = new Farmer
                {
                    FirstName = farmerVM.FirstName,
                    LastName = farmerVM.LastName,
                    Location = farmerVM.Location,
                    PhoneNumber = farmerVM.PhoneNumber,
                    City = farmerVM.City,
                    ProfileImage = result.Url.ToString(),
                    Province = farmerVM.Province,
                    AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                _farmerRepository.AddFarmer(farmer);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(farmerVM);
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Returns the view for editing a farmer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var farmer = await _farmerRepository.GetFarmerById(id);
            if (farmer == null) return View("Error");
            var farmerVM = new EditFarmerViewModel
            {
                FirstName = farmer.FirstName,
                LastName = farmer.LastName,
                Location = farmer.Location,
                PhoneNumber = farmer.PhoneNumber,
                City = farmer.City,
                URL = farmer.ProfileImage,
                Province = farmer.Province,
                AppUserId = farmer.AppUserId,
                AppUser = farmer.AppUser
            };

            return View(farmerVM);
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Edit farmer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="farmerVM"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditFarmerViewModel farmerVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit farmer");
                return View("Edit", farmerVM);
            }

            var userFarmer = await _farmerRepository.GetFarmerByIdAsyncNoTracking(id);

            if (userFarmer == null)
            {
                return View("Error");
            }

            var photoResult = await _photoService.AddPhotoAsync(farmerVM.ProfileImage);

            if (photoResult.Error != null)
            {
                ModelState.AddModelError("Image", "Photo upload failed");
                return View(farmerVM);
            }

            if (!string.IsNullOrEmpty(userFarmer.ProfileImage))
            {
                _ = _photoService.DeletePhotoAsync(userFarmer.ProfileImage);
            }

            var farmer = new Farmer
            {
                Id = id,
                FirstName = farmerVM.FirstName,
                LastName = farmerVM.LastName,
                Location = farmerVM.Location,
                PhoneNumber = farmerVM.PhoneNumber,
                City = farmerVM.City,
                Province = farmerVM.Province,
                ProfileImage = photoResult.Url.ToString(),
                AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                AppUser = farmerVM.AppUser
            };

            _farmerRepository.UpdateFarmer(farmer);

            return RedirectToAction("Index");        
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Deletes a farmer profile
        /// </summary>
        /// <param name = "id" ></ param >
        /// < returns ></ returns >
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteFarmer(int id)
        {
            var farmerDetails = await _farmerRepository.GetFarmerById(id);

            if (farmerDetails == null)
            {
                return View("Error");
            }

            if (!string.IsNullOrEmpty(farmerDetails.ProfileImage))
            {
                _ = _photoService.DeletePhotoAsync(farmerDetails.ProfileImage);
            }

            _farmerRepository.DeleteFarmer(farmerDetails);
            return RedirectToAction("Index");
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> ViewProfile(int id)
        {
            var farmer = await _farmerRepository.GetFarmerById(id);
            if (farmer == null) return View("Error");
            return View(farmer);
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 