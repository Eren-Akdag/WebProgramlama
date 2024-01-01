// Microsoft.AspNetCore.Authorization ve Microsoft.AspNetCore.Mvc isim alanlarını kullanıyoruz.
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// HospitalManagement.Controllers isim alanı içerisindeyiz.
namespace HospitalManagement.Controllers
{
    // Controller sınıfından türetilmiş AdminController sınıfımızı tanımlıyoruz.
    public class AdminController : Controller
    {
        // Yalnızca "Admin" rolündeki kullanıcıların erişebileceği bir işlem.
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            // View() metodu çağrılıyor ve sonuç olarak bir View döndürülüyor.
            return View();
        }
    }
}
