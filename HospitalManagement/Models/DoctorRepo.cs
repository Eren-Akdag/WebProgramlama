// Kullanılan kütüphaneler ve modüller
using HospitalManagement.Data;
using Microsoft.EntityFrameworkCore;

// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // Repo<Doctor> sınıfından türetilmiş ve IDoctorRepo arayüzünü uygulayan DoctorRepo sınıfı
    public class DoctorRepo : Repo<Doctor>, IDoctorRepo
    {
        // ApplicationDbContext tipinde özel bir alan
        ApplicationDbContext _applicationDbContext;

        // Yapıcı metot, temel sınıfın yapıcısına applicationDbContext parametresini geçirir
        public DoctorRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext; // _applicationDbContext alanını başlatır
        }

        // Belirli bir doktorun çalışma saatlerini döndüren metot
        public ICollection<WorkingHours> GetDoctorWorkingHours(int doctorId)
        {
            // Doktorları ve onların çalışma saatlerini içerir ve belirli bir doktoru döndürür
            return _applicationDbContext.Doctors.Include(d => d.WorkingHourses).FirstOrDefault(d => d.Id == doctorId)?.WorkingHourses;
        }

        // Değişiklikleri kaydeden metot
        public void Save()
        {
            _applicationDbContext.SaveChanges(); // Değişiklikleri kaydeder
        }

        // Doktoru güncelleyen metot
        public void Update(Doctor doctor)
        {
            _applicationDbContext.Update(doctor); // Doktoru günceller
        }
    }
}
