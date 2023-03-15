using System.ComponentModel.DataAnnotations;

namespace Travelsal.NetCoreProject.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adınızı giriniz!")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Lütfen Şifrenizi giriniz!")]
        public string Password { get; set; }
    }
}
