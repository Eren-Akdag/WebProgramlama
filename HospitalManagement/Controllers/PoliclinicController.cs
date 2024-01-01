// HospitalManagement.Models, Microsoft.AspNetCore.Authorization ve Microsoft.AspNetCore.Mvc isim alanlarını kullanıyoruz.
using HospitalManagement.Models;
using HospitalManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
	public class PoliclinicController : Controller
	{
        
        // IPoliclinicRepo tipinde bir özel alan tanımlanmıştır.
        private readonly IPoliclinicRepo _policlinicRepo;

        // Yapıcı metot ile IPoliclinicRepo tipindeki nesne enjekte edilmiştir.
        public PoliclinicController(IPoliclinicRepo polikinlikRepository)
        {
            _policlinicRepo = polikinlikRepository;
        }

        // "Admin" ve "Patient" rollerine sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = "Admin,Patient")]
        public IActionResult Index()
        {
            // Polikliniklerin listesini alıyoruz ve bu listeyi görünüme gönderiyoruz.
            List<Policlinic>? objPolikinlikList = _policlinicRepo.GetAll().ToList();
            return View(objPolikinlikList);
        }

        // "Admin" rolüne sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = UserRole.AdminRole)]
        public IActionResult Add()
        {
            // View'ı döndürüyoruz.
            return View();
        }

        // HTTP POST metodu ile yeni bir poliklinik eklemek için bir işlem.
        [Authorize(Roles = UserRole.AdminRole)]
        [HttpPost]
        public IActionResult Add(Policlinic policlinic)
        {
            // Model durumunun geçerli olup olmadığını kontrol ediyoruz.
            if (ModelState.IsValid)
            {
                // Polikliniği ekliyoruz ve değişiklikleri kaydediyoruz.
                _policlinicRepo.Add(policlinic);
                _policlinicRepo.Save();

                // Başarılı mesajını TempData'ya ekliyoruz.
                TempData["basarili"] = "Yeni Polikinlik başarıyla oluşturuldu.";

                // Policlinic controller'ın Index metoduna yönlendiriyoruz.
                return RedirectToAction("Index", "Policlinic");
            }

            // Model durumu geçerli değilse, View'ı döndürüyoruz.
            return View();
        }

        // "Admin" rolüne sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = UserRole.AdminRole)]
        public IActionResult Update(int? id)
        {
            // Eğer id null veya 0 ise, NotFound() döndürülür.
            if (id == null || id == 0) return NotFound();

            // Polikliniği id'ye göre alıyoruz.
            Policlinic? policlinic = _policlinicRepo.Get(u => u.Id == id);
            if (policlinic == null)
            {
                return NotFound();
            }

            // Polikliniği görünüme gönderiyoruz.
            return View(policlinic);
        }

        // HTTP POST metodu ile belirli bir poliklinik için güncelleme işlemi.
        [Authorize(Roles = UserRole.AdminRole)]
        [HttpPost]
        public IActionResult Update(Policlinic policlinic)
        {
            // Model durumunun geçerli olup olmadığını kontrol ediyoruz.
            if (ModelState.IsValid)
            {
                // Polikliniği güncelliyoruz ve değişiklikleri kaydediyoruz.
                _policlinicRepo.Update(policlinic);
                _policlinicRepo.Save();

                // Başarılı mesajını TempData'ya ekliyoruz.
                TempData["basarili"] = "Polikinlik başarıyla güncellendi.";

                // Policlinic controller'ın Index metoduna yönlendiriyoruz.
                return RedirectToAction("Index", "Policlinic");
            }

            // Model durumu geçerli değilse, View'ı döndürüyoruz.
            return View();
        }


        // "Admin" rolüne sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = UserRole.AdminRole)]
        public IActionResult Delete(int? id)
        {
            // Eğer id null veya 0 ise, NotFound() döndürülür.
            if (id == null || id == 0) return NotFound();

            // Polikliniği id'ye göre alıyoruz.
            Policlinic? policlinic = _policlinicRepo.Get(u => u.Id == id);
            if (policlinic == null)
            {
                return NotFound();
            }

            // Polikliniği görünüme gönderiyoruz.
            return View(policlinic);
        }

        // HTTP POST metodu ile belirli bir id'ye sahip polikliniği silmek için bir işlem.
        [Authorize(Roles = UserRole.AdminRole)]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            // Polikliniği id'ye göre alıyoruz.
            Policlinic? policlinic = _policlinicRepo.Get(u => u.Id == id);
            if (policlinic == null) { return NotFound(); }

            // Polikliniği silip değişiklikleri kaydediyoruz.
            _policlinicRepo.Delete(policlinic);
            _policlinicRepo.Save();

            // Başarılı mesajını TempData'ya ekliyoruz.
            TempData["basarili"] = "Silme işlemi başarılı.";

            // Policlinic controller'ın Index metoduna yönlendiriyoruz.
            return RedirectToAction("Index", "Policlinic");
        }

        // Belirli bir id'ye sahip polikliniğin detaylarını görüntülemek için bir işlem.
        public IActionResult Detail(int? id)
        {
            // Eğer id null veya 0 ise, NotFound() döndürülür.
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Polikliniği id'ye göre alıyoruz.
            Policlinic? policlinicVt = _policlinicRepo.Get(u => u.Id == id);
            if (policlinicVt == null)
            {
                return NotFound();
            }

            // Polikliniği görünüme gönderiyoruz.
            return View(policlinicVt);
        }

        // HTTP POST metodu ile belirli bir id'ye sahip polikliniği silmek için bir işlem.
        [HttpPost, ActionName("Detail")]
        public IActionResult DetailPOST(int? id)
        {
            // Polikliniği id'ye göre alıyoruz.
            Policlinic? policlinic = _policlinicRepo.Get(u => u.Id == id);
            if (policlinic == null) { return NotFound(); }

            // Polikliniği silip değişiklikleri kaydediyoruz.
            _policlinicRepo.Delete(policlinic);
            _policlinicRepo.Save();

            // Başarılı mesajını TempData'ya ekliyoruz.
            TempData["basarili"] = "Silme işlemi başarılı.";

            // Policlinic controller'ın Index metoduna yönlendiriyoruz.
            return RedirectToAction("Index");
        }

    }
}

