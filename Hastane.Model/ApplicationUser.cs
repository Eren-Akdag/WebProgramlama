using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public string Nationality { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }

        public string Specialist { get; set; }

        public Department Department { get; set; }

        public ICollection<Appointment> Appointment { get; set; }

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