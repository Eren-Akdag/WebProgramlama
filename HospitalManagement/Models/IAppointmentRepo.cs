namespace HospitalManagement.Models
{
    public interface IAppointmentRepo : IRepo<Appointment>
    {
        void Update(Appointment appointment);
        void Save();

    }
}
