using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HospitalManagement.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Doctor Field Cannot Be Left Blank.")]
        [MaxLength(25)]
        [DisplayName("Doctor Department")]
        public string Department { get; set; }//acılır pencere ile hasta secebilsin


        [Required]
        [DisplayName("Working Hours")]
        [ValidateNever]

        public ICollection<WorkingHours>? WorkingHourses { get; set; }
    }
}
