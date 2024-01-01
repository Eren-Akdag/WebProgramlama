namespace HospitalManagement.Models
{
    public interface IAppointmentRepo : IRepo<Appointment>
    {
        IQueryable<Appointment> GetAll();
        void Update(Appointment appointment);
        void Save();

    }
}
