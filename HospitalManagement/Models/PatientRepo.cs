using HospitalManagement.Data;

namespace HospitalManagement.Models
{
    public class PatientRepo : Repo<Patient>, IPatientRepo
    {
        ApplicationDbContext _applicationDbContext;

        public PatientRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(Patient patient)
        {
            _applicationDbContext.Update(patient);
        }
    }
}
