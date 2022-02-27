using Microsoft.AspNetCore.Identity;

namespace proyectoAlkemy.Models
{
    public class User :  IdentityUser
    {
        public bool isActive{ get; set;}// para hacer bajas lógicas
    }
}
