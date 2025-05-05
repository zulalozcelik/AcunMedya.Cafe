using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.Controllers
{
    public class ErrorpageController : Controller
    {
        [Route("Error/404")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
