//libreria mvc
using Microsoft.AspNetCore.Mvc;
//using proyectoAlkemy.Models;
using proyectoAlkemy.Interfaces;
using proyectoAlkemy.Contexts;
namespace proyectoAlkemy.Controllers
{
    //decoradores para índicar que es una api y ruta y especificar las rutas 
    [ApiController]
    [Route("api/[controller]")]
    
    public class CharactersController: ControllerBase //hereda de la clase base para tener las funcionalidades
    {
        private readonly ICharactersRepository _charactersRepository;
        private readonly DisneyContext _context;

        public CharactersController(ICharactersRepository repository, DisneyContext context1)
        {
            _charactersRepository = repository;
            _context = context1;
        }


        [HttpGet]
        [Route("listCharacters")]

        public IActionResult Get() {

            return Ok(_context.Characters.ToList());
        }
    }

    //public interface Get                
        
}
