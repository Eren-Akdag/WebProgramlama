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
    public class ApiDoctorController : ControllerBase
    {
        // IDoctorRepo tipinde bir özel alan tanımlanmıştır.
        private readonly IDoctorRepo _doctorRepo;

        // Yapıcı metot ile IDoctorRepo tipindeki nesne enjekte edilmiştir.
        public ApiDoctorController(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        // GET: api/Doctors
        // Tüm doktorları getiren bir HTTP GET metodu.
        [HttpGet]
        public IEnumerable<Doctor> GetDoctors()
        {
            return _doctorRepo.GetAll().ToList();
        }

        // GET: api/Doctors/5
        // Belirli bir ID'ye sahip doktoru getiren bir HTTP GET metodu.
        [HttpGet("{id}")]
        public ActionResult<Doctor> GetDoctor(int id)
        {
            var doctor = _doctorRepo.GetAll().FirstOrDefault(d => d.Id == id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        // PUT: api/Doctors/5
        // Belirli bir ID'ye sahip doktoru güncelleyen bir HTTP PUT metodu.
        [HttpPut("{id}")]
        public IActionResult PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            _doctorRepo.Update(doctor);
            _doctorRepo.Save();

            return NoContent();
        }

        // POST: api/Doctors
        // Yeni bir doktor oluşturan bir HTTP POST metodu.
        [HttpPost]
        public ActionResult<Doctor> PostDoctor(Doctor doctor)
        {
            _doctorRepo.Add(doctor);
            _doctorRepo.Save();

            return CreatedAtAction("GetDoctor", new { id = doctor.Id }, doctor);
        }

        // DELETE: api/Doctors/5
        // Belirli bir ID'ye sahip doktoru silen bir HTTP DELETE metodu.
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _doctorRepo.GetAll().FirstOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            _doctorRepo.Delete(doctor);
            _doctorRepo.Save();

            return NoContent();
        }
    }
}
