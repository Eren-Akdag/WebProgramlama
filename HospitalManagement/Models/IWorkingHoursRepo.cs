// HospitalManagement.Data ve HospitalManagement.Models ad alanları (namespaces) içindeki sınıflar
using HospitalManagement.Data;
using HospitalManagement.Models;

// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // IRepo<WorkingHours> arayüzünden türetilmiş IWorkingHoursRepo arayüzü
    public interface IWorkingHoursRepo : IRepo<WorkingHours>
    {
        void Update(WorkingHours workingHours); // Bir çalışma saati kaydını güncelleyen metot

        void Save(); // Değişiklikleri kaydeden metot
    }
}
