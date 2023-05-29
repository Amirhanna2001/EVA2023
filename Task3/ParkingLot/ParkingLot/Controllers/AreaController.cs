using Microsoft.AspNetCore.Mvc;

namespace ParkingLot.Controllers
{
    public class AreaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
