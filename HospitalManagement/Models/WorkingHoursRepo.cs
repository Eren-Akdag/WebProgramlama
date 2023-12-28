using HospitalManagement.Data;

namespace HospitalManagement.Models
{
    public class WorkingHoursRepo : Repo<WorkingHours>, IWorkingHoursRepo
    {

        private ApplicationDbContext _applicationDbContext;

        public WorkingHoursRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(WorkingHours workingHours)
        {
            _applicationDbContext.Update(workingHours);
        }
    }
}
