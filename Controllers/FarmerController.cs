using Microsoft.AspNetCore.Mvc;

namespace ProgPoe_MVC_AgriEnergyConnect.Controllers
{
    public class FarmerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
