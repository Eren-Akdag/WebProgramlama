using HospitalManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
	public class PatientController : Controller
	{

		private readonly IPatientRepo _patientRepo;

		public PatientController(IPatientRepo context)
		{

            _patientRepo = context;
		}
		//[Authorize(Roles = "Admin,Patient")]
		public IActionResult Index()
		{
			List<Patient> objPatientList = _patientRepo.GetAll().ToList();//veritabanına _uygulamadbcontex ile baglanıp doktorlar listesi alıyoruz.
			return View(objPatientList);//view'ev Hasta Listesi gönderiyoruz.
		}


		//[Authorize(Roles = "Admin")]
		public IActionResult Add()
		{
			return View();
		}

		//formdan verileri http post ile alıyoruz ve buraya veriler geliyor
		//veriler Doktor turunden nesne
		//[Authorize(Roles = "Admin")]
		[HttpPost]
		public IActionResult Add(Patient patient)
		{
			if (ModelState.IsValid)
			{
				_patientRepo.Add(patient);//ekleme
				_patientRepo.Save();//kaydetme
				TempData["basarili"] = "yeni hasta listeye başarıyla eklendi.";//kullanıcı mesaj
				return RedirectToAction("Index");//Listele geri donuyor.

			}
			return View();

		}

		//[Authorize(Roles = "Admin")]
		public IActionResult Update(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Patient? patientVT = _patientRepo.Get(u => u.Id == id);//uygulamadbcontex veri tabanina gidip doktorlar tablosundan id degerine göre buluyor
			if (patientVT == null)
			{
				return NotFound();
			}
			return View(patientVT);//doktorVt nesnemizi view'e gönderdik
		}

		[HttpPost]
		public IActionResult Update(Patient patient)
		{
			if (ModelState.IsValid)
			{
				_patientRepo.Update(patient);
				_patientRepo.Save();
				TempData["basarili"] = "Güncelleme işlemi başarılı.";
				return RedirectToAction("Index");
			}
			return View();
		}
		//[Authorize(Roles = "Admin")]
		public IActionResult Delete(int? id)//index.cshtml asp-route-id=@doktor.Id ile id degeri alıyoruz
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Patient? patientVT = _patientRepo.Get(u => u.Id == id);//uygulamadbcontex veri tabanina gidip doktorlar tablosundan id degerine göre buluyor
			if (patientVT == null)
			{
				return NotFound();
			}
			return View(patientVT);//doktorVt nesnemizi view'e gönderdik
		}
		//[Authorize(Roles = "Admin")]
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Patient? patient = _patientRepo.Get(u => u.Id == id);
			if (patient == null) { return NotFound(); }
            _patientRepo.Delete(patient);//sil
            _patientRepo.Save();//kaydet
			TempData["basarili"] = "Silme işlemi başarılı.";//kullaniciya mesaj
			return RedirectToAction("Index");//listele
		}



	}
}
