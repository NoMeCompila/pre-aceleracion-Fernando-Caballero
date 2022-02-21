//libreria mvc
using Microsoft.AspNetCore.Mvc;
using proyectoAlkemy.Models;
using proyectoAlkemy.Interfaces;
using proyectoAlkemy.Contexts;

namespace proyectoAlkemy.Controllers
{
    //decoradores para índicar que es una api y ruta y especificar las rutas 
    [ApiController]
    [Route("api/[controller]")]

    // se hereda del controlador base
    public class MovieSeriesController : ControllerBase
    {
        // se declaran los atriibutos necesarios
        private readonly IMovieSeriesRepository _movieSeriesRepository;
        private readonly DisneyContext _context;

        //se genra la inyeccion por constructor
        public MovieSeriesController(IMovieSeriesRepository movieSeriesRepository, DisneyContext context)
        {
            _movieSeriesRepository = movieSeriesRepository;
            _context = context;
        }

        [HttpGet]
        [Route("allMovieSeries")]
        public IActionResult GetAllMovieSeries() {
            //retornamos un mensaje OK que contiene una lista de las movieseries del contexto actual
            return Ok(_context.MovieSeries.ToList());
        }

        [HttpPost]
        [Route("newMovieSeries")]
        //se pasa como parametro uin objeto de tipo movieSerie
        public IActionResult PostMovieSeries(MovieSerie movieSerie) {
            //service agrega al contexto la nueva serie
            _context.Add(movieSerie);
            //se gaurdan los cambion en el cotnexto
            _context.SaveChanges();
            //se retorna una lista con el objeto agregado
            return Ok(_context.MovieSeries.ToList());
        }

        [HttpPut]
        [Route("modifyMovieSerie")]
        public IActionResult PutMovieSeries(MovieSerie movieSerie)
        {
            //primero hay que saber si la serie o pelicula existe en el contexto o base de datos
            if (_context.MovieSeries.FirstOrDefault(x => x.ID == movieSerie.ID) == null) 
                //si no existe tal objeto entonces se devuelve un error 400 con
                return BadRequest("La Película o Serie no existe.");
            //entonces si el objeto existe se debe generar un  objeto auxiliar para guardar la nueva serie
            var auxMovie = _context.MovieSeries.Find(movieSerie.ID);

            //se guardan los parametros de las peliculas
            auxMovie.Image = movieSerie.Image;
            auxMovie.Title = movieSerie.Title;
            auxMovie.Release_Year = movieSerie.Release_Year;
            auxMovie.Ranking = movieSerie.Ranking;
            auxMovie.Genres = movieSerie.Genres;

            //se guardan los cambios
            _context.SaveChanges();

            //se retorna una lista con el objeto modificado
            return Ok(_context.MovieSeries.ToList());
        }

        [HttpDelete]
        [Route("{id}")]

        public IActionResult DeleteCharact(int id)
        {
            if (_context.MovieSeries.FirstOrDefault(x => x.ID == id) == null) 
                return BadRequest("La película o serie no existe.");

            var auxMovie= _context.MovieSeries.Find(id);

            _context.MovieSeries.Remove(auxMovie);
            _context.SaveChanges();
            return Ok();
        }

    }
}
