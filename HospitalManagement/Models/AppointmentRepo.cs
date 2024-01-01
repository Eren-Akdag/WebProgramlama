using HospitalManagement.Models;
using HospitalManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Models
{
    public class AppointmentRepo : Repo<Appointment>, IAppointmentRepo
    {

        private ApplicationDbContext _applicationDbContext;

        public AppointmentRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IQueryable<Appointment> GetAll() // Bu metodu ekleyin
        {
            return _applicationDbContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Policlinic);
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            _applicationDbContext.Update(appointment);
        }
    }
}
