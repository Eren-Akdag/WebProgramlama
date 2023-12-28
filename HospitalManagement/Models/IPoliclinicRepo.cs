namespace HospitalManagement.Models
{
    public interface IPoliclinicRepo : IRepo<Policlinic>
    {
        void Update(Policlinic policlinic);
        void Save();
    }
}
