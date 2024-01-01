// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // Çalışma saatlerini tutan WorkingHours sınıfı
    public class WorkingHours
    {
        public int Id { get; set; } // Çalışma saatinin benzersiz kimliği

        public string Times { get; set; } // Çalışma saatleri
    }
}
