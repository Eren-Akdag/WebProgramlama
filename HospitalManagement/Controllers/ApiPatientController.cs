using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Models;
using HospitalManagement.Data;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPatientController : ControllerBase 
    {
        private readonly IPatientRepo _patientRepo;

        public ApiPatientController(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        // GET: api/Patients
        [HttpGet]
        public IEnumerable<Patient> GetPatients()
        {
            return _patientRepo.GetAll().ToList();
        }

        // GET: api/Patients/5
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
        [HttpPost]
        public ActionResult<Patient> PostPatient(Patient patient)
        {
            _patientRepo.Add(patient);
            _patientRepo.Save();

            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/5
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

