using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.Models;
using HospitalManagement.Data;

namespace HospitalManagement.Models
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private ApplicationDbContext _applicationDbContext;
        internal DbSet<T> dbSet;

        public Repo(ApplicationDbContext applicationDbContext)
        {

            _applicationDbContext = applicationDbContext;
            dbSet = _applicationDbContext.Set<T>();
            _applicationDbContext.Appointments.Include(r => r.Patient.Name).Include(r => r.Doctor.Name).Include(r => r.Policlinic.Address);

        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public T Get(Expression<Func<T, bool>> filtre, string? includeProps = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filtre);
            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    {
                        query = query.Include(includeProp);
                    }

                }

            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProps = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);

                }
            }
            return query.ToList();
        }
    }
}
