using HospitalManagement.Models;
using HospitalManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyonASP.NET.Controllers
{
	public class PoliclinicController : Controller
	{
		private readonly IPoliclinicRepo _policlinicRepo;//nesnemiz 

		public PoliclinicController(IPoliclinicRepo polikinlikRepository)//
		{
            _policlinicRepo = polikinlikRepository;
		}

		
		public IActionResult Index()//listeleme
		{
			List<Policlinic>? objPolikinlikList = _policlinicRepo.GetAll().ToList();
			return View(objPolikinlikList);
		}

		//[Authorize(Roles =UserRole.AdminRole)]
		public IActionResult Add()
		{
			return View();
		}
        //[Authorize(Roles = UserRole.AdminRole)]
        [HttpPost]
		public IActionResult Add(Policlinic policlinic)
		{
			if (ModelState.IsValid)
			{
                _policlinicRepo.Add(policlinic);
                _policlinicRepo.Save();//SaveChanges yapmaz isen bilgiler veri tabanına eklenmez.
				TempData["basarili"] = "Yeni Polikinlik başarıyla oluşturuldu.";
				return RedirectToAction("Index", "Policlinic");// controller'ın Index metodunu cagirir
			}
			return View();


		}


        //[Authorize(Roles = UserRole.AdminRole)]
        public IActionResult Update(int? id)
		{
			if (id == null || id == 0) return NotFound();//id 0 null kontrolü
			Policlinic? policlinic = _policlinicRepo.Get(u => u.Id == id);//parametre id eşit olan id'yi getir
			if (policlinic == null)
			{
				return NotFound();
			}
			return View(policlinic);
		}

        //[Authorize(Roles = UserRole.AdminRole)]
        [HttpPost]
		public IActionResult Update(Policlinic policlinic)
		{

			if (ModelState.IsValid)
			{
                _policlinicRepo.Update(policlinic);
                _policlinicRepo.Save();//SaveChanges yapmaz isen bilgiler veri tabanına eklenmez.
				TempData["basarili"] = " Polikinlik başarıyla güncellendi.";
				return RedirectToAction("Index", "Policlinic");//KiitapTuru controller'ın Index metodunu cagirir
			}
			return View();

		}

        //SİL
        //[Authorize(Roles = UserRole.AdminRole)]
        public IActionResult Delete(int? id)
		{
			if (id == null || id == 0) return NotFound();//id 0 veya null kontrolü (asp-route-id index.html )
			Policlinic? policlinic = _policlinicRepo.Get(u => u.Id == id);
			if (policlinic == null)
			{
				return NotFound();
			}
			return View(policlinic);
		}

        //[Authorize(Roles = UserRole.AdminRole)]
        [HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Policlinic? policlinic = _policlinicRepo.Get(u => u.Id == id);
			if (policlinic == null) { return NotFound(); }
            _policlinicRepo.Delete(policlinic);
            //_uygulamaDbContext.KitapTurleri.Remove(kitapTuru);
            _policlinicRepo.Save();
			// _uygulamaDbContext.SaveChanges();
			TempData["basarili"] = "Silme işlemi başarılı.";
			return RedirectToAction("Index", "Policlinic");

		}


		//detay


		public IActionResult Detail(int? id)//index.cshtml asp-route-id=@doktor.Id ile id degeri alıyoruz
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Policlinic? policlinicVt = _policlinicRepo.Get(u => u.Id == id);//uygulamadbcontex veri tabanina gidip doktorlar tablosundan id degerine göre buluyor
			if (policlinicVt == null)
			{
				return NotFound();
			}
			return View(policlinicVt);//doktorVt nesnemizi view'e gönderdik
		}

		[HttpPost, ActionName("Detail")]
		public IActionResult DetailPOST(int? id)
		{
			Policlinic? policlinic = _policlinicRepo.Get(u => u.Id == id);
			if (policlinic == null) { return NotFound(); }
            _policlinicRepo.Delete(policlinic);//sil
            _policlinicRepo.Save();//kaydet
			TempData["basarili"] = "Silme işlemi başarılı.";//kullaniciya mesaj
			return RedirectToAction("Index");//listele
		}

	}
}

