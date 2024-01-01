using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Models;
using HospitalManagement.Data;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDoctorController : ControllerBase
    {
        private readonly IDoctorRepo _doctorRepo;

        public ApiDoctorController(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        // GET: api/Doctors
        [HttpGet]
        public IEnumerable<Doctor> GetDoctors()
        {
            return _doctorRepo.GetAll().ToList();
        }

        // GET: api/Doctors/5
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
        [HttpPost]
        public ActionResult<Doctor> PostDoctor(Doctor doctor)
        {
            _doctorRepo.Add(doctor);
            _doctorRepo.Save();

            return CreatedAtAction("GetDoctor", new { id = doctor.Id }, doctor);
        }

        // DELETE: api/Doctors/5
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
