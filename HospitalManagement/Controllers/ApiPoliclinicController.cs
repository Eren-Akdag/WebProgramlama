// System.Linq, Microsoft.AspNetCore.Mvc, HospitalManagement.Models ve HospitalManagement.Data isim alanlarını kullanıyoruz.
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Models;
using HospitalManagement.Data;

// HospitalManagement.Controllers isim alanı içerisindeyiz.
namespace HospitalManagement.Controllers
{
    // Bu sınıfın rotası "api/[controller]" olarak belirlenmiştir ve bu bir API Controller'dır.
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPoliclinicController : ControllerBase
    {
        // IPoliclinicRepo tipinde bir özel alan tanımlanmıştır.
        private readonly IPoliclinicRepo _policlinicRepo;

        // Yapıcı metot ile IPoliclinicRepo tipindeki nesne enjekte edilmiştir.
        public ApiPoliclinicController(IPoliclinicRepo policlinicRepo)
        {
            _policlinicRepo = policlinicRepo;
        }

        // GET: api/Policlinics
        // Tüm poliklinikleri getiren bir HTTP GET metodu.
        [HttpGet]
        public IEnumerable<Policlinic> GetPoliclinics()
        {
            return _policlinicRepo.GetAll().ToList();
        }

        // GET: api/Policlinics/5
        // Belirli bir ID'ye sahip polikliniği getiren bir HTTP GET metodu.
        [HttpGet("{id}")]
        public ActionResult<Policlinic> GetPoliclinic(int id)
        {
            var policlinic = _policlinicRepo.GetAll().FirstOrDefault(p => p.Id == id);

            if (policlinic == null)
            {
                return NotFound();
            }

            return policlinic;
        }

        // PUT: api/Policlinics/5
        // Belirli bir ID'ye sahip polikliniği güncelleyen bir HTTP PUT metodu.
        [HttpPut("{id}")]
        public IActionResult PutPoliclinic(int id, Policlinic policlinic)
        {
            if (id != policlinic.Id)
            {
                return BadRequest();
            }

            _policlinicRepo.Update(policlinic);
            _policlinicRepo.Save();

            return NoContent();
        }

        // POST: api/Policlinics
        // Yeni bir poliklinik oluşturan bir HTTP POST metodu.
        [HttpPost]
        public ActionResult<Policlinic> PostPoliclinic(Policlinic policlinic)
        {
            _policlinicRepo.Add(policlinic);
            _policlinicRepo.Save();

            return CreatedAtAction("GetPoliclinic", new { id = policlinic.Id }, policlinic);
        }

        // DELETE: api/Policlinics/5
        // Belirli bir ID'ye sahip polikliniği silen bir HTTP DELETE metodu.
        [HttpDelete("{id}")]
        public IActionResult DeletePoliclinic(int id)
        {
            var policlinic = _policlinicRepo.GetAll().FirstOrDefault(p => p.Id == id);
            if (policlinic == null)
            {
                return NotFound();
            }

            _policlinicRepo.Delete(policlinic);
            _policlinicRepo.Save();

            return NoContent();
        }
    }
}
