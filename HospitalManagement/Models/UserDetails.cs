using Microsoft.AspNetCore.Identity;

namespace HospitalManagement.Models
{
    public class UserDetails:IdentityUser
    {
        public string UserAd { get; set; }
        public string UserSoyad { get; set; }
    }
}
