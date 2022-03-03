using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using proyectoAlkemy.Models;
using proyectoAlkemy.ViewModels.Auth;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using proyectoAlkemy.Interfaces;

namespace proyectoAlkemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _singInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMailService _mailService;
        public AuthController(UserManager<User> userManager, 
            SignInManager<User> singInManager,
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager,
            IMailService mailService)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _mailService = mailService;
        }

        [HttpPost]
        [Route("registro-admin")]
        public async Task<IActionResult> RegistroAdmin(string userName, string password, string email)
        {
            var userExists = await _userManager.FindByNameAsync(userName);


            if(userExists != null) {
                return StatusCode(StatusCodes.Status400BadRequest, new 
                {

                    StatusCode = "Error",
                    Message = $"User creation failed!, user with name {userName} already exists."
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

            //si no se completo devolver un error del server
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = "Error",
                    Message = "User creation failed!, There was an internal server error."
                });
            }
            //enviamos email
            await _mailService.SendEmail(user);


            if (!await _roleManager.RoleExistsAsync("User"))
                await _roleManager.CreateAsync(new IdentityRole("User"));

            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new IdentityRole("Admin"));

            await _userManager.AddToRoleAsync(user, "Admin");

            
            
            

            //si se completo, devolver Ok();
            return Ok(new
            {
                StatusCode = "Success",
                Message = $"User {user.UserName} was created successfully!"
            });
        }


        [HttpPost]
        [Route("registro")]
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

            //si no se completo devolver un error del server
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    StatusCode = "Error",
                    Message = "User creation failed!, There was an internal server error."
                });
            }

            //enviamos email
            await _mailService.SendEmail(user);

            //si se completo, devolver Ok();
            return Ok(new
            {
                StatusCode = "Success",
                Message = $"User {user.UserName} was created successfully!"
            });
        }

        //login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestViewmodel model)
        {
            //ver si el usuario existe y si la contraseña es correcta
            var result = await _singInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (result.Succeeded)
            {
                //nos aseguramos de que el usuario este activos
                var currentuser = await _userManager.FindByNameAsync(model.UserName);

                if (currentuser.isActive)
                {
                    //si está activo entonces generamos el token
                    return Ok(await GetToken(currentuser));
                }
            }

            //si no es ok devolvemos un codigo de estado 401 unauthorized
            return Unauthorized(new
            {
                Status = "Error",
                Message = $"The user {model.UserName} is not authorized!"
            });
        }

        private async Task<LoginResponseViewModel> GetToken(User currentUser)
        {
            //se levantan los roles
            var userRoles = await _userManager.GetRolesAsync(currentUser);//pregunta que roles tiene un usuario
            
            //se genera la lista de claims del usuario
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, currentUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            //se añade a la lista de claims del token todos los roles que contiene el usuario
            authClaims.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));

            //levantamos nuestra frase cifrada
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            

            //se geenra la estructura inicial del token
            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey,SecurityAlgorithms.HmacSha256)
            );
            
            //devolvemos el token escrito en un string
            return new LoginResponseViewModel
            {
                Token = WriteToken(token),
                ValidTo = token.ValidTo
            };            
        }
        private string WriteToken(JwtSecurityToken token) => new JwtSecurityTokenHandler().WriteToken(token);
    }
}