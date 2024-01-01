// HospitalManagement.Data ad alanı (namespace) içindeki sınıflar
using HospitalManagement.Data;

// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // Repo<Policlinic> sınıfından türetilmiş ve IPoliclinicRepo arayüzünü uygulayan PoliclinicRepo sınıfı
    public class PoliclinicRepo : Repo<Policlinic>, IPoliclinicRepo
    {
        // ApplicationDbContext tipinde özel bir alan
        private ApplicationDbContext _applicationDbContext;

        // Yapıcı metot, temel sınıfın yapıcısına applicationDbContext parametresini geçirir
        public PoliclinicRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext; // _applicationDbContext alanını başlatır
        }

        // Değişiklikleri kaydeden metot
        public void Save()
        {
            _applicationDbContext.SaveChanges(); // Değişiklikleri kaydeder
        }

        // Polikliniği güncelleyen metot
        public void Update(Policlinic policlinic)
        {
            _applicationDbContext.Update(policlinic); // Polikliniği günceller
        }
    }
}
