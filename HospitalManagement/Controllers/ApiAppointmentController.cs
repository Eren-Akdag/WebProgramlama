// System.Linq, Microsoft.AspNetCore.Mvc, Microsoft.EntityFrameworkCore, HospitalManagement.Models ve HospitalManagement.Data isim alanlarını kullanıyoruz.
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.Models;
using HospitalManagement.Data;

// HospitalManagement.Controllers isim alanı içerisindeyiz.
namespace HospitalManagement.Controllers
{
    // Bu sınıfın rotası "api/[controller]" olarak belirlenmiştir ve bu bir API Controller'dır.
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAppointmentController : ControllerBase
    {
        // IAppointmentRepo tipinde bir özel alan tanımlanmıştır.
        private readonly IAppointmentRepo _appointmentRepo;

        // Yapıcı metot ile IAppointmentRepo tipindeki nesne enjekte edilmiştir.
        public ApiAppointmentController(IAppointmentRepo appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        // GET: api/Appointments
        // Tüm randevuları getiren bir HTTP GET metodu.
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
        // Belirli bir ID'ye sahip randevuyu getiren bir HTTP GET metodu.
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
        // Belirli bir ID'ye sahip randevuyu güncelleyen bir HTTP PUT metodu.
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
        // Yeni bir randevu oluşturan bir HTTP POST metodu.
        [HttpPost]
        public ActionResult<Appointment> PostAppointment(Appointment appointment)
        {
            _appointmentRepo.Add(appointment);
            _appointmentRepo.Save();

            return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
        }

        // DELETE: api/Appointments/5
        // Belirli bir ID'ye sahip randevuyu silen bir HTTP DELETE metodu.
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
