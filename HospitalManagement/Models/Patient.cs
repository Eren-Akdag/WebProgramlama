// System.ComponentModel.DataAnnotations ve HospitalManagement.Models ad alanları (namespaces) içindeki sınıflar
using System.ComponentModel.DataAnnotations;
using HospitalManagement.Models;

// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // Hasta bilgilerini tutan Patient sınıfı
    public class Patient
    {
        public int Id { get; set; } // Hastanın benzersiz kimliği

        [Required] // Bu alanın zorunlu olduğunu belirtir
        public string Name { get; set; } // Hastanın adı

        [Required] // Bu alanın zorunlu olduğunu belirtir
        public string Surname { get; set; } // Hastanın soyadı

        [Required] // Bu alanın zorunlu olduğunu belirtir
        public string Telephone { get; set; } // Hastanın telefon numarası

        public string Description { get; set; } // Hastayla ilgili açıklama
    }
}
