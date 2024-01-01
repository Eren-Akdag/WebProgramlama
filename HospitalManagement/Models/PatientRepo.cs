// HospitalManagement.Data ad alanı (namespace) içindeki sınıflar
using HospitalManagement.Data;

// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // Repo<Patient> sınıfından türetilmiş ve IPatientRepo arayüzünü uygulayan PatientRepo sınıfı
    public class PatientRepo : Repo<Patient>, IPatientRepo
    {
        // ApplicationDbContext tipinde özel bir alan
        ApplicationDbContext _applicationDbContext;

        // Yapıcı metot, temel sınıfın yapıcısına applicationDbContext parametresini geçirir
        public PatientRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext; // _applicationDbContext alanını başlatır
        }

        // Değişiklikleri kaydeden metot
        public void Save()
        {
            _applicationDbContext.SaveChanges(); // Değişiklikleri kaydeder
        }

        // Hastayı güncelleyen metot
        public void Update(Patient patient)
        {
            _applicationDbContext.Update(patient); // Hastayı günceller
        }
    }
}
