using System.ComponentModel.DataAnnotations;
using HospitalManagement.Models;

namespace HospitalManagement.Models
{
    public class Policlinic
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Polyclinic Name field cannot be left blank.")]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
