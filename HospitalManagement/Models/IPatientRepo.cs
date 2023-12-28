namespace HospitalManagement.Models
{
    public interface IPatientRepo:IRepo<Patient>
    {
        void Update(Patient patient);
        void Save();
    }
}
