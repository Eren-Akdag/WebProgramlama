using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HospitalManagement.Models;
using HospitalManagement.Data;

namespace HospitalManagement.Models
{
    public class Appointment
    {
        public int Id { get; set; }//Randevu
        [Required]
        public DateTime Dates { get; set; }


        public String? Description { get; set; }

        public String AppointmentTime { get; set; }


        [ValidateNever]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        [ValidateNever]
        public Patient Patient { get; set; }


        [ValidateNever]
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        [ValidateNever]
        public Doctor Doctor { get; set; }


        [ValidateNever]
        public int PoliclinicId { get; set; }
        [ForeignKey("PoliclinicId")]
        [ValidateNever]
        public Policlinic Policlinic { get; set; }
    }
}
