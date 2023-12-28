using System.ComponentModel.DataAnnotations;
using HospitalManagement.Models;

namespace HospitalManagement.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Telephone { get; set; }

        public string Description { get; set; }
    }
}
