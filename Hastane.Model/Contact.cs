namespace Hastane.Model
{
    public class Contact
    {
        public int Id { get; set; }

        public int HospitalId { get; set; }

        public HastaneInfoo Hastane { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

    }
}