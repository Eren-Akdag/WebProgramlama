// Kullanılan kütüphaneler ve modüller
using HospitalManagement.Models;
using HospitalManagement.Data;
using Microsoft.EntityFrameworkCore;

// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // Repo<Appointment> sınıfından türetilmiş ve IAppointmentRepo arayüzünü uygulayan AppointmentRepo sınıfı
    public class AppointmentRepo : Repo<Appointment>, IAppointmentRepo
    {
        // ApplicationDbContext tipinde özel bir alan
        private ApplicationDbContext _applicationDbContext;

        // Yapıcı metot, temel sınıfın yapıcısına applicationDbContext parametresini geçirir
        public AppointmentRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext; // _applicationDbContext alanını başlatır
        }

        // Tüm randevuları döndüren metot
        public IQueryable<Appointment> GetAll() // Bu metodu ekleyin
        {
            return _applicationDbContext.Appointments // Randevuları döndürür
                .Include(a => a.Patient) // Hastaları dahil eder
                .Include(a => a.Doctor) // Doktorları dahil eder
                .Include(a => a.Policlinic); // Poliklinikleri dahil eder
        }

        // Değişiklikleri kaydeden metot
        public void Save()
        {
            _applicationDbContext.SaveChanges(); // Değişiklikleri kaydeder
        }

        // Randevuyu güncelleyen metot
        public void Update(Appointment appointment)
        {
            _applicationDbContext.Update(appointment); // Randevuyu günceller
        }
    }
}
