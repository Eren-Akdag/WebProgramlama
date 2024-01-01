using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.Models;
using HospitalManagement.Data;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAppointmentController : ControllerBase
    {
        private readonly IAppointmentRepo _appointmentRepo;

        public ApiAppointmentController(IAppointmentRepo appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        // GET: api/Appointments
        [HttpGet]
        public IEnumerable<Appointment> GetAppointments()
        {
            return _appointmentRepo.GetAll()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Policlinic)
                .ToList();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public ActionResult<Appointment> GetAppointment(int id)
        {
            var appointment = _appointmentRepo.GetAll()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Policlinic)
                .FirstOrDefault(a => a.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // PUT: api/Appointments/5
        [HttpPut("{id}")]
        public IActionResult PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            _appointmentRepo.Update(appointment);
            _appointmentRepo.Save();

            return NoContent();
        }

        // POST: api/Appointments
        [HttpPost]
        public ActionResult<Appointment> PostAppointment(Appointment appointment)
        {
            _appointmentRepo.Add(appointment);
            _appointmentRepo.Save();

            return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            var appointment = _appointmentRepo.GetAll()
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Policlinic)
                .FirstOrDefault(a => a.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            _appointmentRepo.Delete(appointment);
            _appointmentRepo.Save();

            return NoContent();
        }
    }
}
