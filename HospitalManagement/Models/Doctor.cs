// Kullanılan kütüphaneler ve modüller
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // Doktor bilgilerini tutan Doctor sınıfı
    public class Doctor
    {
        public int Id { get; set; } // Doktorun benzersiz kimliği

        [Required] // Bu alanın zorunlu olduğunu belirtir
        public string Name { get; set; } // Doktorun adı

        [Required] // Bu alanın zorunlu olduğunu belirtir
        public string Surname { get; set; } // Doktorun soyadı

        [Required(ErrorMessage = "Doctor Field Cannot Be Left Blank.")] // Bu alanın zorunlu olduğunu ve boş bırakılamayacağını belirtir
        [MaxLength(25)] // Bu alanın maksimum uzunluğunun 25 karakter olduğunu belirtir
        [DisplayName("Doctor Department")] // Bu alanın görünen adının "Doctor Department" olduğunu belirtir
        public string Department { get; set; } // Doktorun bölümü

        [Required] // Bu alanın zorunlu olduğunu belirtir
        [DisplayName("Working Hours")] // Bu alanın görünen adının "Working Hours" olduğunu belirtir
        [ValidateNever] // Bu alanın doğrulanmaması gerektiğini belirtir
        public ICollection<WorkingHours>? WorkingHourses { get; set; } // Doktorun çalışma saatlerini tutan koleksiyon
    }
}
