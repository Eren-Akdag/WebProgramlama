// HospitalManagement.Migrations, HospitalManagement.Models, Microsoft.AspNetCore.Authorization, Microsoft.AspNetCore.Mvc, Microsoft.AspNetCore.Mvc.Rendering, Microsoft.CodeAnalysis.CSharp ve Microsoft.EntityFrameworkCore isim alanlarını kullanıyoruz.
using HospitalManagement.Migrations;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;


// HospitalManagement.Controllers isim alanı içerisindeyiz.
namespace HospitalManagement.Controllers
{
	public class AppointmentController : Controller
	{
        // IAppointmentRepo, IPatientRepo, IDoctorRepo ve IPoliclinicRepo tipinde özel alanlar tanımlanmıştır.
        private readonly IAppointmentRepo _appointmentRepo;
        private readonly IPatientRepo _patientRepo;
        private readonly IDoctorRepo _doctorRepo;
        private readonly IPoliclinicRepo _policlinicRepo;

        // Yapıcı metot ile IAppointmentRepo, IPatientRepo, IDoctorRepo ve IPoliclinicRepo tipindeki nesneler enjekte edilmiştir.
        public AppointmentController(IAppointmentRepo appointment, IPatientRepo patient, IDoctorRepo doctor, IPoliclinicRepo policlinic)
        {
            _appointmentRepo = appointment;
            _patientRepo = patient;
            _doctorRepo = doctor;
            _policlinicRepo = policlinic;
        }

        // "Admin" ve "Patient" rollerine sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = "Admin,Patient")]
        public IActionResult Index()
        {
            // Randevuların listesini alıyoruz ve bu listeyi görünüme gönderiyoruz.
            List<Appointment> objRandevuList = _appointmentRepo.GetAll(includeProps: "Patient,Doctor,Policlinic").ToList();
            return View(objRandevuList);
        }


        // "Admin" ve "Patient" rollerine sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = "Admin,Patient")]
        public IActionResult Add()
        {
            // Hastaların listesini alıyoruz ve bu listeyi bir SelectListItem listesi olarak oluşturuyoruz.
            IEnumerable<SelectListItem> PatientList = _patientRepo.GetAll().Select(h => new SelectListItem
            {
                Text = h.Name, // hasta adı
                Value = h.Id.ToString(), // hasta id
            });
            ViewBag.PatientList = PatientList;

            // Doktorların listesini alıyoruz ve bu listeyi bir SelectListItem listesi olarak oluşturuyoruz.
            IEnumerable<SelectListItem> DoctorList = _doctorRepo.GetAll().Select(d => new SelectListItem
            {
                Text = d.Name, // doktor adı
                Value = d.Id.ToString(), // doktor id
            });
            ViewBag.DoctorList = DoctorList;

            // Polikliniklerin listesini alıyoruz ve bu listeyi bir SelectListItem listesi olarak oluşturuyoruz.
            IEnumerable<SelectListItem> PoliclinicList = _policlinicRepo.GetAll().Select(p => new SelectListItem
            {
                Text = p.Name, // poliklinik adı
                Value = p.Id.ToString(), // poliklinik id
            });
            ViewBag.PoliclinicList = PoliclinicList;

            // Doktorların çalışma saatlerini alıyoruz ve bu listeyi bir SelectListItem listesi olarak oluşturuyoruz.
            IEnumerable<SelectListItem> DoctorWorkingHoursList = _doctorRepo.GetAll().Select(d => new SelectListItem
            {
                Text = (d.WorkingHourses).ToString(), // doktorun çalışma saatleri
                Value = d.Id.ToString() // doktor id
            });
            ViewBag.DoctorWorkingHoursList = DoctorWorkingHoursList;

            // View'ı döndürüyoruz.
            return View();
        }

        // "Admin" ve "Patient" rollerine sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = "Admin,Patient")]
        [HttpPost]
        public IActionResult Add(Appointment appointment)
        {
            // Model durumunun geçerli olup olmadığını kontrol ediyoruz.
            if (ModelState.IsValid)
            {
                // Randevuyu ekliyoruz ve değişiklikleri kaydediyoruz.
                _appointmentRepo.Add(appointment);
                _appointmentRepo.Save();

                // Başarılı mesajını TempData'ya ekliyoruz.
                TempData["basarili"] = "Yeni Randevu Randevu Listesine başarıyla Eklendi.";

                // Randevu controller'ın Index metoduna yönlendiriyoruz.
                return RedirectToAction("Index", "Appointment");
            }
            // Model durumu geçerli değilse, View'ı döndürüyoruz.
            return View();
        }



        // "Admin" rolüne sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int? id)
        {
            // Hastaların, doktorların, polikliniklerin ve doktorların çalışma saatlerinin listelerini alıyoruz.
            // Bu listeleri bir SelectListItem listesi olarak oluşturuyoruz ve ViewBag ile görünüme gönderiyoruz.
            IEnumerable<SelectListItem> PatientList = _patientRepo.GetAll().Select(h => new SelectListItem
            {
                Text = h.Name, // hasta adı
                Value = h.Id.ToString(), // hasta id
            });
            ViewBag.PatientList = PatientList;

            IEnumerable<SelectListItem> DoctorList = _doctorRepo.GetAll().Select(d => new SelectListItem
            {
                Text = d.Name, // doktor adı
                Value = d.Id.ToString(), // doktor id
            });
            ViewBag.DoctorList = DoctorList;

            IEnumerable<SelectListItem> PoliclinicList = _policlinicRepo.GetAll().Select(p => new SelectListItem
            {
                Text = p.Name, // poliklinik adı
                Value = p.Id.ToString(), // poliklinik id
            });
            ViewBag.PoliclinicList = PoliclinicList;

            IEnumerable<SelectListItem> DoctorWorkingHoursList = _doctorRepo.GetAll().Select(d => new SelectListItem
            {
                Text = (d.WorkingHourses).ToString(), // doktorun çalışma saatleri
                Value = d.Id.ToString() // doktor id
            });
            ViewBag.DoctorWorkingHoursList = DoctorWorkingHoursList;

            // Eğer id null veya 0 ise, NotFound() döndürülür.
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Randevuyu id'ye göre alıyoruz.
            Appointment? appointmentVt = _appointmentRepo.Get(u => u.Id == id);
            if (appointmentVt == null)
            {
                return NotFound();
            }

            // Randevuyu görünüme gönderiyoruz.
            return View(appointmentVt);
        }

        // HTTP POST metodu ile randevuyu güncelliyoruz.
        [HttpPost]
        public IActionResult Update(Appointment appointment)
        {
            // Model durumunun geçerli olup olmadığını kontrol ediyoruz.
            if (ModelState.IsValid)
            {
                // Randevuyu güncelliyoruz ve değişiklikleri kaydediyoruz.
                _appointmentRepo.Update(appointment);
                _appointmentRepo.Save();

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
            // Hastaların, doktorların, polikliniklerin ve doktorların çalışma saatlerinin listelerini alıyoruz.
            // Bu listeleri bir SelectListItem listesi olarak oluşturuyoruz ve ViewBag ile görünüme gönderiyoruz.
            IEnumerable<SelectListItem> PatientList = _patientRepo.GetAll().Select(h => new SelectListItem
            {
                Text = h.Name, // hasta adı
                Value = h.Id.ToString(), // hasta id
            });
            ViewBag.PatientList = PatientList;

            IEnumerable<SelectListItem> DoctorList = _doctorRepo.GetAll().Select(d => new SelectListItem
            {
                Text = d.Name, // doktor adı
                Value = d.Id.ToString(), // doktor id
            });
            ViewBag.DoctorList = DoctorList;

            IEnumerable<SelectListItem> PoliclinicList = _policlinicRepo.GetAll().Select(p => new SelectListItem
            {
                Text = p.Address, // poliklinik adresi
                Value = p.Id.ToString(), // poliklinik id
            });
            ViewBag.PoliclinicList = PoliclinicList;

            IEnumerable<SelectListItem> DoctorWorkingHoursList = _doctorRepo.GetAll().Select(d => new SelectListItem
            {
                Text = (d.WorkingHourses).ToString(), // doktorun çalışma saatleri
                Value = d.Id.ToString() // doktor id
            });
            ViewBag.DoctorWorkingHoursList = DoctorWorkingHoursList;

            // Eğer id null veya 0 ise, NotFound() döndürülür.
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Randevuyu id'ye göre alıyoruz.
            Appointment? appointmentVT = _appointmentRepo.Get(u => u.Id == id);
            if (appointmentVT == null)
            {
                return NotFound();
            }

            // Randevuyu görünüme gönderiyoruz.
            return View(appointmentVT);
        }

        // "Admin" rolüne sahip kullanıcıların erişimine açık bir işlem.
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            // Randevuyu id'ye göre alıyoruz.
            Appointment? appointment = _appointmentRepo.Get(u => u.Id == id);
            if (appointment == null) { return NotFound(); }

            // Randevuyu silip değişiklikleri kaydediyoruz.
            _appointmentRepo.Delete(appointment);
            _appointmentRepo.Save();

            // Başarılı mesajını TempData'ya ekliyoruz.
            TempData["basarili"] = "Silme işlemi başarılı.";

            // Index metoduna yönlendiriyoruz.
            return RedirectToAction("Index");
        }

        // Doktorun çalışma saatlerini alıyoruz ve bu saatleri bir JSON olarak döndürüyoruz.
        public JsonResult LoadState(int doktorId)
        {
            var workingHours = _doctorRepo.GetDoctorWorkingHours(doktorId);
            return Json(workingHours);
        }

    }
}
