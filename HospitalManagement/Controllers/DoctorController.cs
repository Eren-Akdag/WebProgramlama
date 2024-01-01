// Microsoft.AspNetCore.Mvc, Microsoft.AspNetCore.Authorization, Microsoft.AspNetCore.Mvc.Rendering, Newtonsoft.Json, HospitalManagement.Models ve HospitalManagement.Data isim alanlarını kullanıyoruz.
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using HospitalManagement.Models;
using HospitalManagement.Data;

// HospitalManagement.Controllers isim alanı içerisindeyiz.

namespace HospitalManagement.Controllers
{
    public class DoctorController : Controller
    {

        // IDoctorRepo tipinde bir özel alan ve IWebHostEnvironment tipinde bir özel alan tanımlanmıştır.
        private readonly IDoctorRepo _doctorRepo;
        public readonly IWebHostEnvironment _webHostEnvironment;

        // Yapıcı metot ile IDoctorRepo ve IWebHostEnvironment tipindeki nesneler enjekte edilmiştir.
        public DoctorController(IDoctorRepo context, IWebHostEnvironment webHostEnvironment)
        {
            _doctorRepo = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // "Admin" ve "Patient" rollerine sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = "Admin,Patient")]
        public IActionResult Index()
        {
            // Doktorların listesini alıyoruz ve her doktorun çalışma saatlerini ayarlıyoruz.
            List<Doctor> objDoktorList = _doctorRepo.GetAll().ToList();
            foreach (var doctor in objDoktorList)
            {
                doctor.WorkingHourses = _doctorRepo.GetDoctorWorkingHours(doctor.Id);
            }

            // Doktorların listesini görünüme gönderiyoruz.
            return View(objDoktorList);
        }

        // "Admin" rolüne sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = UserRole.AdminRole)]
        public IActionResult AddUpdate(int? id)
        {
            // Doktorların listesini alıyoruz ve bu listeyi bir SelectListItem listesi olarak oluşturuyoruz.
            IEnumerable<SelectListItem> DoctorList = _doctorRepo.GetAll().Select(k => new SelectListItem
            {
                Text = k.Name, // doktor adı
                Value = k.Id.ToString(), // doktor id
            });
            ViewBag.DoctorList = DoctorList;

            // Eğer id null veya 0 ise, View'ı döndürülür.
            if (id == null || id == 0)
            {
                return View();
            }
            else
            {
                // Doktoru id'ye göre alıyoruz.
                Doctor? DoctorVt = _doctorRepo.Get(u => u.Id == id);
                if (DoctorVt == null)
                {
                    return NotFound();
                }

                // Doktoru görünüme gönderiyoruz.
                return View(DoctorVt);
            }
        }

        // "Admin" rolüne sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = UserRole.AdminRole)]
        [HttpPost]
        public IActionResult AddUpdate(Doctor doctor, IFormFile? file)
        {
            // Model durumunun geçerli olup olmadığını kontrol ediyoruz.
            if (ModelState.IsValid)
            {
                // Eğer doktorun id'si 0 ise, doktoru ekliyoruz.
                if (doctor.Id == 0)
                {
                    _doctorRepo.Add(doctor);
                    TempData["basarili"] = "Yeni doktor listeye başarıyla eklendi."; // kullanıcıya mesaj
                }
                else
                {
                    // Doktoru güncelliyoruz.
                    _doctorRepo.Update(doctor);
                    TempData["basarili"] = "Güncelleme işlemi başarılı."; // kullanıcıya mesaj
                }

                // Değişiklikleri kaydediyoruz.
                _doctorRepo.Save();

                // Index metoduna yönlendiriyoruz.
                return RedirectToAction("Index");
            }

            // Model durumu geçerli değilse, View'ı döndürüyoruz.
            return View();
        }



        // Belirli bir id'ye sahip doktorun detaylarını görüntülemek için bir işlem.
        public IActionResult Detail(int? id)
        {
            // Eğer id null veya 0 ise, NotFound() döndürülür.
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Doktoru id'ye göre alıyoruz.
            Doctor? doctorVt = _doctorRepo.Get(u => u.Id == id);
            if (doctorVt == null)
            {
                return NotFound();
            }

            // Doktoru görünüme gönderiyoruz.
            return View(doctorVt);
        }

        // HTTP POST metodu ile belirli bir id'ye sahip doktoru silmek için bir işlem.
        [HttpPost, ActionName("DetailDelete")]
        public IActionResult DetailPOST(int? id)
        {
            // Doktoru id'ye göre alıyoruz.
            Doctor? doctor = _doctorRepo.Get(u => u.Id == id);
            if (doctor == null) { return NotFound(); }

            // Doktoru silip değişiklikleri kaydediyoruz.
            _doctorRepo.Delete(doctor);
            _doctorRepo.Save();

            // Başarılı mesajını TempData'ya ekliyoruz.
            TempData["success"] = "The deletion was successful.";

            // Index metoduna yönlendiriyoruz.
            return RedirectToAction("Index");
        }

        // "Admin" rolüne sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = UserRole.AdminRole)]
        public IActionResult Delete(int? id)
        {
            // Eğer id null veya 0 ise, NotFound() döndürülür.
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Doktoru id'ye göre alıyoruz.
            Doctor? doctorVt = _doctorRepo.Get(u => u.Id == id);
            if (doctorVt == null)
            {
                return NotFound();
            }

            // Doktoru görünüme gönderiyoruz.
            return View(doctorVt);
        }

        // "Admin" rolüne sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = UserRole.AdminRole)]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            // Doktoru id'ye göre alıyoruz.
            Doctor? doctor = _doctorRepo.Get(u => u.Id == id);
            if (doctor == null) { return NotFound(); }

            // Doktoru silip değişiklikleri kaydediyoruz.
            _doctorRepo.Delete(doctor);
            _doctorRepo.Save();

            // Başarılı mesajını TempData'ya ekliyoruz.
            TempData["basarili"] = "Silme işlemi başarılı.";

            // Index metoduna yönlendiriyoruz.
            return RedirectToAction("Index");
        }


    }
}
