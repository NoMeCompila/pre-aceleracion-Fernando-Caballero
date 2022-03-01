//libreria mvc
using Microsoft.AspNetCore.Mvc;
using proyectoAlkemy.Models;
using proyectoAlkemy.Interfaces;
using proyectoAlkemy.Contexts;
using Microsoft.EntityFrameworkCore;
//view model
using proyectoAlkemy.ViewModels.Characters;
using Microsoft.AspNetCore.Authorization;

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

        public async Task<IActionResult> GetDetailCharacters([FromQuery] CharacterRequestDetailViewModel model) {

            //var characters = _context.Characters.Include(x => x.MovieSeries).ThenInclude(y => y.Genres).ToList();

            var characters = _context.Characters.Include(x => x.MovieSeries).ToList();

            if (!string.IsNullOrEmpty(model.Name)){
                characters = characters.Where(x => x.Name == model.Name).ToList();
            }
            
            if (!string.IsNullOrEmpty(model.Age.ToString())){
                characters = characters.Where(x => x.Age == model.Age).ToList();
            }

            if (model.MovieSeriesID.Any())
            {
                characters = characters.Where(x => x.MovieSeries.Any(y => model.MovieSeriesID.Contains(y.ID))).ToList();
            }


            if (!characters.Any()) return NoContent();

            var responseViewModel = new List<CharacterResponsetDetailViewModel>();

            foreach (var character in characters) {
                responseViewModel.Add(new CharacterResponsetDetailViewModel()
                {
                    Image = character.Image,
                    Name = character.Name,
                    Age = character.Age,
                    Weight = character.Weight,
                    Lore = character.Lore
                    //MovieSeriesID = character.MovieSeries.Contains(model.MovieSeriesID)
                });
            }
            return Ok(responseViewModel);

        }
        /*
        [HttpGet]
        [Route("GetRelatedData")]
        public IActionResult RelateData()
        {
            //characters = characters.Where(x => x.MovieSeries.Any(y => model.MovieSeriesID.Contains(y.ID))).ToList();
            var characters = _context.Characters.Include(x => x.MovieSeries).ToList();
            return Ok(characters);
        }*/


        [HttpGet]
        [Route("charactes")]
        [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> PostCharacter(CharacterPostViewModel charact)
        {
            //se genera una entidad del modelo con los datos minimos para llenar los campos del ViewModel
            Characters character = new Characters { 
                Image = charact.Image,
                Name = charact.Name,
                Age = charact.Age,
                Weight = charact.Weight,
                Lore = charact.Lore
            };
            
            //se añade al contexto se guardan cambios y se retorna
            _charactersRepository.Add(character);
            _context.SaveChanges();
            return Ok(_context.Characters.ToList());

        }

        /* 
        //solucion anterior que trae la entidad completa
        public IActionResult PostCharacter(Characters charact) {

            _context.Characters.Add(charact);
            _context.SaveChanges();
            return Ok(_context.Characters.ToList());
        }*/


        [HttpPut]
        [Route("modifyCharcater")]
        public IActionResult PutCharacter(CharacterPutViewModel character)
        {

            if (_context.Characters.FirstOrDefault(x => x.ID == character.ID) == null) 
                return BadRequest("El personaje no existe.");

            var auxCharacter = _context.Characters.Find(character.ID);

            auxCharacter.Image = character.Image;
            auxCharacter.Name = character.Name;
            auxCharacter.Weight = character.Weight;
            auxCharacter.Age = character.Age;
            auxCharacter.Lore = character.Lore;



            _context.SaveChanges();
            return Ok(_context.Characters.ToList());
        }

        /*
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
        }*/

        [HttpDelete]
        [Route("{id}")]

        public IActionResult DeleteCharact(int id) {
            if (_context.Characters.FirstOrDefault(x => x.ID == id) == null) return BadRequest("El personaje no existe.");

            var auxCharacter = _context.Characters.Find(id);

            _context.Characters.Remove(auxCharacter);
            _context.SaveChanges();
            return Ok(_context.Characters.ToList());
        }
    }

    //public interface Get                
        
}
