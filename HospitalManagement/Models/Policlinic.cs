// System.ComponentModel.DataAnnotations ve HospitalManagement.Models ad alanları (namespaces) içindeki sınıflar
using System.ComponentModel.DataAnnotations;
using HospitalManagement.Models;

// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // Poliklinik bilgilerini tutan Policlinic sınıfı
    public class Policlinic
    {
        public int Id { get; set; } // Polikliniğin benzersiz kimliği

        [Required(ErrorMessage = "Polyclinic Name field cannot be left blank.")] // Bu alanın zorunlu olduğunu ve boş bırakılamayacağını belirtir
        [MaxLength(30)] // Bu alanın maksimum uzunluğunun 30 karakter olduğunu belirtir
        public string Name { get; set; } // Polikliniğin adı

        public string Address { get; set; } // Polikliniğin adresi
    }
}
