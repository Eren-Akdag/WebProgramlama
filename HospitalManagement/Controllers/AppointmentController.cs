using HospitalManagement.Migrations;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Controllers
{
	public class AppointmentController : Controller
	{
		private readonly IAppointmentRepo _appointmentRepo;
		private readonly IPatientRepo _patientRepo;
		private readonly IDoctorRepo _doctorRepo;
		private readonly IPoliclinicRepo _policlinicRepo;


		public AppointmentController(IAppointmentRepo appointment, IPatientRepo patient, IDoctorRepo doctor, IPoliclinicRepo policlinic)
		{
            _appointmentRepo = appointment;
            _patientRepo = patient;
            _doctorRepo = doctor;
            _policlinicRepo = policlinic;
		}
		//[Authorize(Roles = "Admin,Patient")]
		public IActionResult Index()
		{
			//List<Randevu> objRandevuList = _randevuRepository.GetAll().ToList();//veritabanına _uygulamadbcontex ile baglanıp  listesi alıyoruz.
			List<Appointment> objRandevuList = _appointmentRepo.GetAll(includeProps:"Patient,Doctor,Policlinic").ToList();
			return View(objRandevuList);//view'ev  Listesi gönderiyoruz.
		}
		//[Authorize(Roles = "Admin,Patient")]
		public IActionResult Add()
		{
			//HASTALAR
			IEnumerable<SelectListItem> PatientList = _patientRepo.GetAll().Select(h => new SelectListItem //hasta  alıyor
			{                                                                                                   //drop-down şeklinde	
				Text = h.Name,//hasta ad
				Value = h.Id.ToString(),//hasta id

			});
			ViewBag.PatientList = PatientList;
			//DOKTORLAR
			IEnumerable<SelectListItem> DoctorList = _doctorRepo.GetAll().Select(d => new SelectListItem //doktor  alıyor
			{                                                                                                   //drop-down şeklinde	
				Text = d.Name,//doktor ad
				Value = d.Id.ToString(),//doktor id

			});
			ViewBag.DoctorList = DoctorList;

			//POLİKİNLİKLER
			IEnumerable<SelectListItem> PoliclinicList = _policlinicRepo.GetAll().Select(p => new SelectListItem //doktoralan  alıyor
			{                                                                                                   //drop-down şeklinde	
				Text = p.Name,//polikinlik adres
				Value = p.Id.ToString(),//polikinlik id

			});
			ViewBag.PoliclinicList = PoliclinicList;


			IEnumerable<SelectListItem> DoctorWorkingHoursList = _doctorRepo.GetAll().Select(d => new SelectListItem
			{                                                                                                   //drop-down şeklinde	
				Text = (d.WorkingHourses).ToString(),
				Value = d.Id.ToString()

			}) ;
			ViewBag.DoctorWorkingHoursList = DoctorWorkingHoursList;

			return View();
		}

		//[Authorize(Roles = "Admin,Patient")]
		[HttpPost]
		public IActionResult Add(Appointment appointment)
		{
			if (ModelState.IsValid)
			{
                _appointmentRepo.Add(appointment);
                _appointmentRepo.Save();//SaveChanges yapmaz isen bilgiler veri tabanına eklenmez.
				TempData["basarili"] = "Yeni Randevu Randevu Listesine başarıyla Eklendi.";
				return RedirectToAction("Index", "Appointment");//Randevu controller'ın Index metodunu cagirir
			}
			return View();
		
		}

		//[Authorize(Roles = "Admin")]
		public IActionResult Update(int? id)
		{
			#region VeriCekme


			//HASTALAR
			IEnumerable<SelectListItem> PatientList = _patientRepo.GetAll().Select(h => new SelectListItem //hasta  alıyor
			{                                                                                                   //drop-down şeklinde	
				Text = h.Name,//hasta ad
				Value = h.Id.ToString(),//hasta id

			});
			ViewBag.PatientList = PatientList;
			//DOKTORLAR
			IEnumerable<SelectListItem> DoctorList = _doctorRepo.GetAll().Select(d => new SelectListItem //doktor  alıyor
			{                                                                                                   //drop-down şeklinde	
				Text = d.Name,//doktor ad
				Value = d.Id.ToString(),//doktor id

			});
			ViewBag.DoctorList = DoctorList;

			//POLİKİNLİKLER
			IEnumerable<SelectListItem> PoliclinicList = _policlinicRepo.GetAll().Select(p => new SelectListItem //doktoralan  alıyor
			{                                                                                                   //drop-down şeklinde	
				Text = p.Name,//polikinlik adres
				Value = p.Id.ToString(),//polikinlik id

			});
			ViewBag.PoliclinicList = PoliclinicList;


			IEnumerable<SelectListItem> DoctorWorkingHoursList = _doctorRepo.GetAll().Select(d => new SelectListItem
			{                                                                                                   //drop-down şeklinde	
				Text = (d.WorkingHourses).ToString(),
				Value = d.Id.ToString()

			});
			ViewBag.DoctorWorkingHoursList = DoctorWorkingHoursList;

			#endregion

			if (id == null || id == 0)
			{
				return NotFound();
			}
			Appointment? appointmentVt = _appointmentRepo.Get(u => u.Id == id);//uygulamadbcontex veri tabanina gidip doktorlar tablosundan id degerine göre buluyor
			if (appointmentVt == null)
			{
				return NotFound();
			}
			return View(appointmentVt);//doktorVt nesnemizi view'e gönderdik
		}

		[HttpPost]
		public IActionResult Update(Appointment appointment)
		{
			if (ModelState.IsValid)
			{
				_appointmentRepo.Update(appointment);
                _appointmentRepo.Save();
				TempData["basarili"] = "Güncelleme işlemi başarılı.";
				return RedirectToAction("Index");
			}
			return View();
		}







		//[Authorize(Roles = "Admin")]
		public IActionResult Sil(int? id)//index.cshtml asp-route-id=@doktor.Id ile id degeri alıyoruz
		{
			#region VeriCekme


			//HASTALAR
			IEnumerable<SelectListItem> PatientList = _patientRepo.GetAll().Select(h => new SelectListItem //hasta  alıyor
			{                                                                                                   //drop-down şeklinde	
				Text = h.Name,//hasta ad
				Value = h.Id.ToString(),//hasta id

			});
			ViewBag.PatientList = PatientList;
			//DOKTORLAR
			IEnumerable<SelectListItem> DoctorList = _doctorRepo.GetAll().Select(d => new SelectListItem //doktor  alıyor
			{                                                                                                   //drop-down şeklinde	
				Text = d.Name,//doktor ad
				Value = d.Id.ToString(),//doktor id

			});
			ViewBag.DoctorList = DoctorList;

			//POLİKİNLİKLER
			IEnumerable<SelectListItem> PoliclinicList = _policlinicRepo.GetAll().Select(p => new SelectListItem //doktoralan  alıyor
			{                                                                                                   //drop-down şeklinde	
				Text = p.Address,//polikinlik adres
				Value = p.Id.ToString(),//polikinlik id

			});
			ViewBag.PoliclinicList = PoliclinicList;


			IEnumerable<SelectListItem> DoctorWorkingHoursList = _doctorRepo.GetAll().Select(d => new SelectListItem
			{                                                                                                   //drop-down şeklinde	
				Text = (d.WorkingHourses).ToString(),
				Value = d.Id.ToString()

			});
			ViewBag.DoctorWorkingHoursList = DoctorWorkingHoursList;

			#endregion



			if (id == null || id == 0)
			{
				return NotFound();
			}
			Appointment? appointmentVT = _appointmentRepo.Get(u => u.Id == id);//uygulamadbcontex veri tabanina gidip doktorlar tablosundan id degerine göre buluyor
			if (appointmentVT == null)
			{
				return NotFound();
			}
			return View(appointmentVT);//doktorVt nesnemizi view'e gönderdik
		}
		//[Authorize(Roles = "Admin")]
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Appointment? appointment = _appointmentRepo.Get(u => u.Id == id);
			if (appointment == null) { return NotFound(); }
            _appointmentRepo.Delete(appointment);//sil
            _appointmentRepo.Save();//kaydet
			TempData["basarili"] = "Silme işlemi başarılı.";//kullaniciya mesaj
			return RedirectToAction("Index");//listele
		}



		//CALISMASAATLERI DKTOR
		public JsonResult LoadState(int doktorId)
		{
			var workingHours=_doctorRepo.GetDoctorWorkingHours(doktorId);
			return Json(workingHours);
		}

	}
}
