using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hastane.Model
{
    public class ApplicationUser : IdentityUser
    {



        public string Name { get; set; }

        public Gender Gender { get; set; }

        public string Nationality { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }

        public string Specialist { get; set; }

        public bool IsDoctors { get; set; }

        public string PictureUri { get; set; }

        public Department Department { get; set; }
        [NotMapped]

        public ICollection<Appointment> Appointment { get; set; }
        [NotMapped]

        public ICollection<Payroll> Payroll { get; set; }

    }
}
  
namespace Hastane.Model
{
    public enum Gender
    {
        Male,Female,Orher
    }
}