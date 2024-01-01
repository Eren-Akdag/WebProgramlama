// Kullanılan kütüphaneler ve modüller
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HospitalManagement.Models;
using HospitalManagement.Data;

// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // Randevu bilgilerini tutan Appointment sınıfı
    public class Appointment
    {
        public int Id { get; set; } // Randevunun benzersiz kimliği

        [Required] // Bu alanın zorunlu olduğunu belirtir
        public DateTime Dates { get; set; } // Randevu tarihi

        public String? Description { get; set; } // Randevu ile ilgili açıklama

        public String AppointmentTime { get; set; } // Randevu saati

        [ValidateNever] // Bu alanın doğrulanmaması gerektiğini belirtir
        public int PatientId { get; set; } // Hastanın benzersiz kimliği
        [ForeignKey("PatientId")] // PatientId'nin yabancı anahtar olduğunu belirtir
        [ValidateNever] // Bu alanın doğrulanmaması gerektiğini belirtir
        public Patient Patient { get; set; } // Hastayı temsil eden nesne

        [ValidateNever] // Bu alanın doğrulanmaması gerektiğini belirtir
        public int DoctorId { get; set; } // Doktorun benzersiz kimliği
        [ForeignKey("DoctorId")] // DoctorId'nin yabancı anahtar olduğunu belirtir
        [ValidateNever] // Bu alanın doğrulanmaması gerektiğini belirtir
        public Doctor Doctor { get; set; } // Doktoru temsil eden nesne

        [ValidateNever] // Bu alanın doğrulanmaması gerektiğini belirtir
        public int PoliclinicId { get; set; } // Polikliniğin benzersiz kimliği
        [ForeignKey("PoliclinicId")] // PoliclinicId'nin yabancı anahtar olduğunu belirtir
        [ValidateNever] // Bu alanın doğrulanmaması gerektiğini belirtir
        public Policlinic Policlinic { get; set; } // Polikliniği temsil eden nesne
    }
}

