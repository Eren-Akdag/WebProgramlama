// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // IRepo<Appointment> arayüzünden türetilmiş IAppointmentRepo arayüzü
    public interface IAppointmentRepo : IRepo<Appointment>
    {
        IQueryable<Appointment> GetAll(); // Tüm randevuları döndüren metot

        void Update(Appointment appointment); // Bir randevuyu güncelleyen metot

        void Save(); // Değişiklikleri kaydeden metot
    }
}
