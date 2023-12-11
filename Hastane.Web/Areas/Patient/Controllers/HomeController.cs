using Microsoft.AspNetCore.Mvc;

namespace Hastane.Web.Areas.Patient.Controllers
{

    [Area("Patient")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
