// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // IRepo<Policlinic> arayüzünden türetilmiş IPoliclinicRepo arayüzü
    public interface IPoliclinicRepo : IRepo<Policlinic>
    {
        void Update(Policlinic policlinic); // Bir polikliniği güncelleyen metot

        void Save(); // Değişiklikleri kaydeden metot
    }
}
