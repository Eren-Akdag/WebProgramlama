namespace Hastane.Model
{
    public class Room
    {
        public int Id { get; set; }

        public string RoomNumber { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public int HospitalId { get; set; }

        public Hastane Hastane { get; set; }
    }
}