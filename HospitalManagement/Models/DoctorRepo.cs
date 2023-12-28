using HospitalManagement.Data;
using Microsoft.EntityFrameworkCore;


namespace HospitalManagement.Models
{
    public class DoctorRepo : Repo<Doctor>, IDoctorRepo
    {

        ApplicationDbContext _applicationDbContext;

        public DoctorRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public ICollection<WorkingHours> GetDoctorWorkingHours(int doctorId)
        {
            return _applicationDbContext.Doctors.Include(d => d.WorkingHourses).FirstOrDefault(d => d.Id == doctorId)?.WorkingHourses;
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(Doctor doctor)
        {
            _applicationDbContext.Update(doctor);
        }
    }
}
