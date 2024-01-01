// HospitalManagement.Models, Microsoft.AspNetCore.Mvc, Microsoft.CodeAnalysis.Host, System.Diagnostics, Microsoft.AspNetCore.Localization, Newtonsoft.Json ve HospitalManagement.Services isim alanlarını kullanıyoruz.
using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using System.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Newtonsoft.Json;
using HospitalManagement.Services;

// HospitalManagement.Controllers isim alanı içerisindeyiz.
namespace HospitalManagement.Controllers
{
    // HomeController sınıfımız bir Controller'dır.
    public class HomeController : Controller
    {
        // ILogger<HomeController> ve LanguageService tipinde iki özel alan tanımlanmıştır.
        private readonly ILogger<HomeController> _logger;
        private LanguageService _localization;

        // Yapıcı metot ile ILogger<HomeController> ve LanguageService tipindeki nesneler enjekte edilmiştir.
        public HomeController(ILogger<HomeController> logger, LanguageService localization)
        {
            _logger = logger;
            _localization = localization;
        }

        // Index işlemi.
        public IActionResult Index()
        {
            // "Welcome" anahtarının değerini alıyoruz ve bu değeri ViewBag.Welcome'a atıyoruz.
            ViewBag.Welcome = _localization.Getkey("Welcome").Value;

            // Mevcut kültürü alıyoruz.
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            // View'ı döndürüyoruz.
            return View();
        }

        // Dil değiştirme işlemi.
        public IActionResult ChangeLanguage(string culture)
        {
            // Yeni kültür değerini bir çerezde saklıyoruz.
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });

            // Önceki sayfaya yönlendiriyoruz.
            return Redirect(Request.Headers["Referer"].ToString());
        }

        // Gizlilik politikası sayfası işlemi.
        public IActionResult Faq()
        {
            // View'ı döndürüyoruz.
            return View();
        }

        // Hata sayfası işlemi.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Yeni bir ErrorViewModel oluşturuyoruz ve bu modeli View'ı döndürüyoruz.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
