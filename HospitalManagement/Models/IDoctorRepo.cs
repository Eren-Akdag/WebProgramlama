using HospitalManagement.Models;

namespace HospitalManagement.Models
{
    public interface IDoctorRepo:IRepo<Doctor>
    {
        void Update(Doctor doctor);
        void Save();
        ICollection<WorkingHours> GetDoctorWorkingHours(int doctorId);
    }
}
