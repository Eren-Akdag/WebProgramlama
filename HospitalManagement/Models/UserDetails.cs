// Microsoft.AspNetCore.Identity ad alanı (namespace) içindeki sınıflar
using Microsoft.AspNetCore.Identity;

// HospitalManagement.Models ad alanı (namespace) içindeki sınıflar
namespace HospitalManagement.Models
{
    // IdentityUser sınıfından türetilmiş UserDetails sınıfı
    public class UserDetails : IdentityUser
    {
        public string UserAd { get; set; } // Kullanıcının adı

        public string UserSoyad { get; set; } // Kullanıcının soyadı
    }
}
