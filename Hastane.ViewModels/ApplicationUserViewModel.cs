using Hastane.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.ViewModels
{
    public class ApplicationUserViewModel
    {
        public List<ApplicationUser> Doctors { get; set; } = new List<ApplicationUser>();

        public string Name { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        //public string Password { get; set; }

        public string City { get; set; }

        public Gender Gender { get; set; }

        public bool IsDoctors { get; set; }

        public string Specilist { get; set; }

        public ApplicationUserViewModel() 
        {

        }

        public ApplicationUserViewModel(ApplicationUser user)
        {
            Name = user.Name;
            City = user.City;
            Gender gender = user.Gender;
            IsDoctors = user.IsDoctors;
            Specilist = user.Specialist;
            UserName = user.UserName;
            Email = user.Email;
        }

        public ApplicationUser ConvertViewModelToModel(ApplicationUserViewModel user)
        {
            return new ApplicationUser
            {
                Name = user.Name,
                City = user.City,
                Gender = user.Gender,
                IsDoctors = user.IsDoctors,
                Specialist = user.Specilist,
                Email = user.Email,
                UserName = user.UserName
            };              
        }

    }
}
