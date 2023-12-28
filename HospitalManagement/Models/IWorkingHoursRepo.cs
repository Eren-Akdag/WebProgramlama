using HospitalManagement.Data;
using HospitalManagement.Models;

namespace HospitalManagement.Models
{
    public interface IWorkingHoursRepo : IRepo<WorkingHours>
    {
        void Update(WorkingHours workingHours);
        void Save();
    }
}
