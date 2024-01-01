// System.Linq.Expressions ad alanı (namespace) içindeki sınıflar
using System.Linq.Expressions;

// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // T tipinde bir sınıf için genel repository arayüzü
    public interface IRepo<T> where T : class
    {
        // Tüm varlıkları döndüren metot
        IEnumerable<T> GetAll(string? includeProps = null);

        // Belirli bir filtre ile bir varlık döndüren metot
        T Get(Expression<Func<T, bool>> filtre, string? includeProps = null);

        // Bir varlık ekleyen metot
        void Add(T entity);

        // Bir varlık silen metot
        void Delete(T entity);

        // Birden fazla varlık silen metot
        void DeleteRange(IEnumerable<T> entities);
    }
}
