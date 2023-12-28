using HospitalManagement.Data;

namespace HospitalManagement.Models
{
    public class PoliclinicRepo : Repo<Policlinic>, IPoliclinicRepo
    {
        private ApplicationDbContext _applicationDbContext;

        public PoliclinicRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(Policlinic policlinic)
        {
            _applicationDbContext.Update(policlinic);
        }
    }
}
