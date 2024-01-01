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
    public class ApiPatientController : ControllerBase
    {
        // IPatientRepo tipinde bir özel alan tanımlanmıştır.
        private readonly IPatientRepo _patientRepo;

        // Yapıcı metot ile IPatientRepo tipindeki nesne enjekte edilmiştir.
        public ApiPatientController(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        // GET: api/Patients
        // Tüm hastaları getiren bir HTTP GET metodu.
        [HttpGet]
        public IEnumerable<Patient> GetPatients()
        {
            return _patientRepo.GetAll().ToList();
        }

        // GET: api/Patients/5
        // Belirli bir ID'ye sahip hastayı getiren bir HTTP GET metodu.
        [HttpGet("{id}")]
        public ActionResult<Patient> GetPatient(int id)
        {
            var patient = _patientRepo.GetAll().FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // PUT: api/Patients/5
        // Belirli bir ID'ye sahip hastayı güncelleyen bir HTTP PUT metodu.
        [HttpPut("{id}")]
        public IActionResult PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            _patientRepo.Update(patient);
            _patientRepo.Save();

            return NoContent();
        }

        // POST: api/Patients
        // Yeni bir hasta oluşturan bir HTTP POST metodu.
        [HttpPost]
        public ActionResult<Patient> PostPatient(Patient patient)
        {
            _patientRepo.Add(patient);
            _patientRepo.Save();

            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/5
        // Belirli bir ID'ye sahip hastayı silen bir HTTP DELETE metodu.
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _patientRepo.GetAll().FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            _patientRepo.Delete(patient);
            _patientRepo.Save();

            return NoContent();
        }
    }
}

