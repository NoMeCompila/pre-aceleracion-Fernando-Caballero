using System.ComponentModel.DataAnnotations;

namespace proyectoAlkemy.ViewModels.Auth
{
    public class LoginRequestViewmodel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
