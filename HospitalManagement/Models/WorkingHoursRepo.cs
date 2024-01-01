// HospitalManagement.Data ad alanı (namespace) içindeki sınıflar
using HospitalManagement.Data;

// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // Repo<WorkingHours> sınıfından türetilmiş ve IWorkingHoursRepo arayüzünü uygulayan WorkingHoursRepo sınıfı
    public class WorkingHoursRepo : Repo<WorkingHours>, IWorkingHoursRepo
    {
        // ApplicationDbContext tipinde özel bir alan
        private ApplicationDbContext _applicationDbContext;

        // Yapıcı metot, temel sınıfın yapıcısına applicationDbContext parametresini geçirir
        public WorkingHoursRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext; // _applicationDbContext alanını başlatır
        }

        // Değişiklikleri kaydeden metot
        public void Save()
        {
            _applicationDbContext.SaveChanges(); // Değişiklikleri kaydeder
        }

        // Çalışma saatlerini güncelleyen metot
        public void Update(WorkingHours workingHours)
        {
            _applicationDbContext.Update(workingHours); // Çalışma saatlerini günceller
        }
    }
}
