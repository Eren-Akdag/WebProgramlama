 using Microsoft.AspNetCore.Mvc;

namespace Hastane.Web.Areas.Admin.Controllers
{
    public class HastanesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
