// HospitalManagement.Models, Microsoft.AspNetCore.Authorization ve Microsoft.AspNetCore.Mvc isim alanlarını kullanıyoruz.
using HospitalManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
	public class PatientController : Controller
	{
        
        // IPatientRepo tipinde bir özel alan tanımlanmıştır.
        private readonly IPatientRepo _patientRepo;

        // Yapıcı metot ile IPatientRepo tipindeki nesne enjekte edilmiştir.
        public PatientController(IPatientRepo context)
        {
            _patientRepo = context;
        }

        // "Admin" ve "Patient" rollerine sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = "Admin,Patient")]
        public IActionResult Index()
        {
            // Hastaların listesini alıyoruz ve bu listeyi görünüme gönderiyoruz.
            List<Patient> objPatientList = _patientRepo.GetAll().ToList();
            return View(objPatientList);
        }

        // "Admin" rolüne sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            // View'ı döndürüyoruz.
            return View();
        }

        // HTTP POST metodu ile yeni bir hasta eklemek için bir işlem.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(Patient patient)
        {
            // Model durumunun geçerli olup olmadığını kontrol ediyoruz.
            if (ModelState.IsValid)
            {
                // Hastayı ekliyoruz ve değişiklikleri kaydediyoruz.
                _patientRepo.Add(patient);
                _patientRepo.Save();

                // Başarılı mesajını TempData'ya ekliyoruz.
                TempData["basarili"] = "Yeni hasta listeye başarıyla eklendi.";

                // Index metoduna yönlendiriyoruz.
                return RedirectToAction("Index");
            }

            // Model durumu geçerli değilse, View'ı döndürüyoruz.
            return View();
        }

        // "Admin" rolüne sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int? id)
        {
            // Eğer id null veya 0 ise, NotFound() döndürülür.
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Hastayı id'ye göre alıyoruz.
            Patient? patientVT = _patientRepo.Get(u => u.Id == id);
            if (patientVT == null)
            {
                return NotFound();
            }

            // Hastayı görünüme gönderiyoruz.
            return View(patientVT);
        }


        // HTTP POST metodu ile belirli bir hasta için güncelleme işlemi.
        [HttpPost]
        public IActionResult Update(Patient patient)
        {
            // Model durumunun geçerli olup olmadığını kontrol ediyoruz.
            if (ModelState.IsValid)
            {
                // Hastayı güncelliyoruz ve değişiklikleri kaydediyoruz.
                _patientRepo.Update(patient);
                _patientRepo.Save();

                // Başarılı mesajını TempData'ya ekliyoruz.
                TempData["basarili"] = "Güncelleme işlemi başarılı.";

                // Index metoduna yönlendiriyoruz.
                return RedirectToAction("Index");
            }

            // Model durumu geçerli değilse, View'ı döndürüyoruz.
            return View();
        }

        // "Admin" rolüne sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            // Eğer id null veya 0 ise, NotFound() döndürülür.
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Hastayı id'ye göre alıyoruz.
            Patient? patientVT = _patientRepo.Get(u => u.Id == id);
            if (patientVT == null)
            {
                return NotFound();
            }

            // Hastayı görünüme gönderiyoruz.
            return View(patientVT);
        }

        // "Admin" rolüne sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            // Hastayı id'ye göre alıyoruz.
            Patient? patient = _patientRepo.Get(u => u.Id == id);
            if (patient == null) { return NotFound(); }

            // Hastayı silip değişiklikleri kaydediyoruz.
            _patientRepo.Delete(patient);
            _patientRepo.Save();

            // Başarılı mesajını TempData'ya ekliyoruz.
            TempData["basarili"] = "Silme işlemi başarılı.";

            // Index metoduna yönlendiriyoruz.
            return RedirectToAction("Index");
        }

    }
}
