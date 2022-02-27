using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using proyectoAlkemy.Models;

namespace proyectoAlkemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        public AuthController(UserManager<User> userManager) {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(string userName, string password, string email)
        {
            //revisar si existe el usuario
            var userExists = await _userManager.FindByNameAsync(userName);

            if (userExists != null) {
                return BadRequest(new{

                    StatusCode = "Error",
                    Message = "User creation failed!, user already exists."
                });
            }

            //si no existe el usuario entonces agregarlo
            var user = new User
            {
                UserName = userName,
                Email = email,
                isActive = true
            };

            var result = await _userManager.CreateAsync(user, password);

            //sin no se completo devolver un error del server
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = "Error",
                    Message = "User creation failed!, There weas an internal server error."
                });
            }

            //si se completo, devolver Ok();
            return Ok(new
            {
                StatusCode = "Success",
                Message = $"User {user.UserName} was created successfully!"
            });
        }
    }
}
