// System.Linq.Expressions, Microsoft.EntityFrameworkCore, HospitalManagement.Models ve HospitalManagement.Data ad alanları (namespaces) içindeki sınıflar
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.Models;
using HospitalManagement.Data;

// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // T tipinde bir sınıf için genel repository sınıfı
    public class Repo<T> : IRepo<T> where T : class
    {
        // ApplicationDbContext tipinde özel bir alan
        private ApplicationDbContext _applicationDbContext;
        // DbSet<T> tipinde özel bir alan
        internal DbSet<T> dbSet;

        // Yapıcı metot, applicationDbContext parametresini alır
        public Repo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext; // _applicationDbContext alanını başlatır
            dbSet = _applicationDbContext.Set<T>(); // dbSet alanını başlatır
            // Randevuları ve onların hastalarının adlarını, doktorlarının adlarını ve polikliniklerinin adreslerini içerir
            _applicationDbContext.Appointments.Include(r => r.Patient.Name).Include(r => r.Doctor.Name).Include(r => r.Policlinic.Address);
        }

        // Bir varlık ekleyen metot
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        // Bir varlık silen metot
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        // Birden fazla varlık silen metot
        public void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        // Belirli bir filtre ile bir varlık döndüren metot
        public T Get(Expression<Func<T, bool>> filtre, string? includeProps = null)
        {
            IQueryable<T> query = dbSet; // IQueryable<T> tipinde bir sorgu oluşturur
            query = query.Where(filtre); // Sorguyu belirli bir filtreye göre filtreler
            // Eğer includeProps boş değilse
            if (!string.IsNullOrEmpty(includeProps))
            {
                // includeProps'u virgüllere göre ayırır ve her bir özelliği sorguya dahil eder
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault(); // Sorgunun ilk sonucunu döndürür
        }

        // Tüm varlıkları döndüren metot
        public IEnumerable<T> GetAll(string? includeProps = null)
        {
            IQueryable<T> query = dbSet; // IQueryable<T> tipinde bir sorgu oluşturur
            // Eğer includeProps boş değilse
            if (!string.IsNullOrEmpty(includeProps))
            {
                // includeProps'u virgüllere göre ayırır ve her bir özelliği sorguya dahil eder
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList(); // Sorgunun tüm sonuçlarını bir liste olarak döndürür
        }
    }
}

