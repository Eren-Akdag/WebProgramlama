// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // IRepo<Doctor> arayüzünden türetilmiş IDoctorRepo arayüzü
    public interface IDoctorRepo : IRepo<Doctor>
    {
        void Update(Doctor doctor); // Bir doktoru güncelleyen metot

        void Save(); // Değişiklikleri kaydeden metot

        ICollection<WorkingHours> GetDoctorWorkingHours(int doctorId); // Belirli bir doktorun çalışma saatlerini döndüren metot
    }
}
