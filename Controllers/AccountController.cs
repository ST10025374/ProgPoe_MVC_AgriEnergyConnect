using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgPoe_MVC_AgriEnergyConnect.Data;
using ProgPoe_MVC_AgriEnergyConnect.Models;
using ProgPoe_MVC_AgriEnergyConnect.ViewModels;

namespace ProgPoe_MVC_AgriEnergyConnect.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// The user manager.
        /// </summary>
        private readonly UserManager<AppUser> _userManager;

        /// <summary>
        /// The sign-in manager.
        /// </summary>
        private readonly SignInManager<AppUser> _signInManager;

        /// <summary>
        /// The application context.
        /// </summary>
        private readonly ApplicationDbContext _context;

        //---------------------------------------------------------------------//      
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign-in manager.</param>
        /// <param name="context">The application context.</param>
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Displays Login View
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Logs in the user with the provided credentials.
        /// </summary>
        /// <param name="loginViewModel">The login view model containing the user's email and password.</param>
        /// <returns>Returns an IActionResult representing the result of the login operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);

            if (user != null)
            {
                //User exists, check password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    //Password is correct, sign in
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                //Password is incorrect
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(loginViewModel);
            }
            //User does not exist
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginViewModel);
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Displays the registration view.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="registerViewModel">The register view model containing the user's registration information.</param>
        /// <returns>Returns an IActionResult representing the result of the registration operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            //Check if user already exists
            var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerViewModel);
            }

            var newUser = new AppUser()
            {
                Email = registerViewModel.EmailAddress,
                UserName = registerViewModel.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);//Farmer Role

            return RedirectToAction("Index", "Home");       
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Logs out the user.
        /// </summary>
        /// <returns>Returns an IActionResult representing the result of the logout operation.</returns>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 