using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using HospitalManagement.Models;
using HospitalManagement.Data;

namespace HospitalManagement.Controllers
{
    public class DoctorController : Controller
    {

        private readonly IDoctorRepo _doctorRepo;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public DoctorController(IDoctorRepo context, IWebHostEnvironment webHostEnvironment)
        {

            _doctorRepo = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "Admin,Patient")]
        public IActionResult Index()
        {
            List<Doctor> objDoktorList = _doctorRepo.GetAll().ToList();
            foreach (var doctor in objDoktorList)
            {
                doctor.WorkingHourses = _doctorRepo.GetDoctorWorkingHours(doctor.Id);
            }
            return View(objDoktorList);
        }

        [Authorize(Roles = UserRole.AdminRole)]
        public IActionResult AddUpdate(int? id)
        {
            //comboox hasta id seçiliyo
            IEnumerable<SelectListItem> DoctorList = _doctorRepo.GetAll().Select(k => new SelectListItem
            {
                Text = k.Name,
                Value = k.Id.ToString()

            }
            );

            ViewBag.DoctorList = DoctorList;
            if (id == null || id == 0)
            {
                return View();
            }
            else
            {

                Doctor? DoctorVt = _doctorRepo.Get(u => u.Id == id);//uygulamadbcontex veri tabanina gidip doktorlar tablosundan id degerine göre buluyor
                if (DoctorVt == null)
                {
                    return NotFound();
                }
                return View(DoctorVt);
            }

        }

        [Authorize(Roles = UserRole.AdminRole)]
        [HttpPost]
        public IActionResult AddUpdate(Doctor doctor, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                

                if (doctor.Id == 0)
                {
                    _doctorRepo.Add(doctor);
                    TempData["basarili"] = "yeni doktor listeye başarıyla eklendi.";//kullanıcı mesaj

                }
                else
                {
                    _doctorRepo.Update(doctor);
                    TempData["basarili"] = "güncelleme işlemi başarılı.";//kullanıcı mesaj

                }
                _doctorRepo.Save();
                return RedirectToAction("Index");//Listele geri donuyor.

            }
            return View();
        }

        public IActionResult Detail(int? id)//index.cshtml asp-route-id=@doktor.Id ile id degeri alıyoruz
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Doctor? doctorVt = _doctorRepo.Get(u => u.Id == id);//uygulamadbcontex veri tabanina gidip doktorlar tablosundan id degerine göre buluyor
            if (doctorVt == null)
            {
                return NotFound();
            }
            return View(doctorVt);//doktorVt nesnemizi view'e gönderdik
        }

        [HttpPost, ActionName("DetailDelete")]
        public IActionResult DetailPOST(int? id)
        {
            Doctor? doctor = _doctorRepo.Get(u => u.Id == id);
            if (doctor == null) { return NotFound(); }
            _doctorRepo.Delete(doctor);//sil
            _doctorRepo.Save();//kaydet
            TempData["success"] = "The deletion was successful.";//kullaniciya mesaj
            return RedirectToAction("Index");//listele
        }

        [Authorize(Roles = UserRole.AdminRole)]
        public IActionResult Delete(int? id)//index.cshtml asp-route-id=@doktor.Id ile id degeri alıyoruz
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Doctor? doctorVt = _doctorRepo.Get(u => u.Id == id);//uygulamadbcontex veri tabanina gidip doktorlar tablosundan id degerine göre buluyor
            if (doctorVt == null)
            {
                return NotFound();
            }
            return View(doctorVt);//doktorVt nesnemizi view'e gönderdik
        }

        [Authorize(Roles = UserRole.AdminRole)]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Doctor? doctor = _doctorRepo.Get(u => u.Id == id);
            if (doctor == null) { return NotFound(); }
            _doctorRepo.Delete(doctor);//sil
            _doctorRepo.Save();//kaydet
            TempData["basarili"] = "Silme işlemi başarılı.";//kullaniciya mesaj
            return RedirectToAction("Index");//listele
        }
    }
}
