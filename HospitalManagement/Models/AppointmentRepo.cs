using HospitalManagement.Models;
using HospitalManagement.Data;

namespace HospitalManagement.Models
{
    public class AppointmentRepo : Repo<Appointment>, IAppointmentRepo
    {

        private ApplicationDbContext _applicationDbContext;

        public AppointmentRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
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
