//libreria mvc
using Microsoft.AspNetCore.Mvc;
using proyectoAlkemy.Models;
using proyectoAlkemy.Interfaces;
using proyectoAlkemy.Contexts;
//view model
using proyectoAlkemy.ViewModels.Characters;

namespace proyectoAlkemy.Controllers
{
    //decoradores para índicar que es una api y ruta y especificar las rutas 
    [ApiController]
    [Route("api/[controller]")]

    public class CharactersController : ControllerBase //hereda de la clase base para tener las funcionalidades
    {
        private readonly ICharactersRepository _charactersRepository;
        private readonly DisneyContext _context;

        public CharactersController(ICharactersRepository repository, DisneyContext context1)
        {
            _charactersRepository = repository;
            _context = context1;
        }

        [HttpGet]
        [Route("getDetailCharacters")]

        public async Task<IActionResult> GetDetailCharacters([FromQuery] CharacterGetDetailViewModel model) { 
            
            var characters = _context.Characters.ToList();

            if (!string.IsNullOrEmpty(model.Name)){
                characters = characters.Where(x=>x.Name == model.Name).ToList();
            }
            
            if (!string.IsNullOrEmpty(model.Age.ToString())){
                characters = characters.Where(x => x.Age == model.Age).ToList();
            }
            
            if (!string.IsNullOrEmpty(model.Weight.ToString()))
            {
                characters = characters.Where(x => x.Weight == model.Weight).ToList();
            }
            
            /*
            if (!string.IsNullOrEmpty(model.MovieSeries.ToString()))
            {
                List<int> aux = new List<int>();
                
                foreach(var charact in characters)
                {

                }
                
                //characters = ;
            }*/


            if (!characters.Any()) return NoContent();

            var responseViewModel = new List<CharacterGetDetailViewModel>();

            foreach (var character in characters) {
                responseViewModel.Add(new CharacterGetDetailViewModel()
                {
                    Image = character.Image,
                    Name = character.Name,
                    Age = character.Age,
                    Weight = character.Weight,
                    Lore = character.Lore//,
                    //MovieSeriesID = character.ID
                });
            
            }
            return Ok(responseViewModel);

        }




        [HttpGet]
        [Route("charactes")]
        public IActionResult DetallesPersonajes() {
            var characters = _context.Characters.ToList();
            if (!characters.Any()) return NoContent();
            var responseViewModel = new List<CharactersGetResponseViewModel>();
            foreach (var character in characters) {
                responseViewModel.Add( new CharactersGetResponseViewModel()
                {
                    Image = character.Image,
                    Name = character.Name
                });
            }
            return Ok(responseViewModel);
        }



        [HttpGet]
        [Route("AllCharacters")]
        public IActionResult GetAllCharacters()
        {
            return Ok(_context.Characters.ToList());
        }

        [HttpPost]
        [Route("newCharcater")]
        public IActionResult PostCharacter(Characters charact) {

            _context.Characters.Add(charact);
            _context.SaveChanges();
            return Ok(_context.Characters.ToList());
        }


        [HttpPut]
        [Route("modifyCharcater")]

        public IActionResult PutCharacter(Characters character) {

            if (_context.Characters.FirstOrDefault(x => x.ID == character.ID) == null) return BadRequest("El personaje no existe.");

            var auxCharacter = _context.Characters.Find(character.ID);

            auxCharacter.Image = character.Image;
            auxCharacter.Name = character.Name;
            auxCharacter.Weight = character.Weight;
            auxCharacter.Age = character.Age;
            auxCharacter.Lore = character.Lore;

            _context.SaveChanges();

            return Ok(_context.Characters.ToList());
        }

        [HttpDelete]
        [Route("{id}")]

        public IActionResult DeleteCharact(int id) {
            if (_context.Characters.FirstOrDefault(x => x.ID == id) == null) return BadRequest("El personaje no existe.");

            var auxCharacter = _context.Characters.Find(id);

            _context.Characters.Remove(auxCharacter);
            _context.SaveChanges();
            return Ok();
        }
    }

    //public interface Get                
        
}
