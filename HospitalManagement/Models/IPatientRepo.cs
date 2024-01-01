// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // IRepo<Patient> arayüzünden türetilmiş IPatientRepo arayüzü
    public interface IPatientRepo : IRepo<Patient>
    {
        void Update(Patient patient); // Bir hastayı güncelleyen metot

        void Save(); // Değişiklikleri kaydeden metot
    }
}
