using Microsoft.AspNetCore.Mvc;
using proyectoAlkemy.Models;
using proyectoAlkemy.Interfaces;
using proyectoAlkemy.Contexts;
using proyectoAlkemy.ViewModels.MovieSeries;
using Microsoft.EntityFrameworkCore;

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
        [Route("search_movieSeries")]
        public async Task<IActionResult> GetMVS([FromQuery] MoviesGetRequestViewModel model)
        {
           
            var movies = _context.MovieSeries.Include(x => x.Genres).ToList();

            if (!string.IsNullOrEmpty(model.Title))
            {
                movies = movies.Where(x => x.Title == model.Title).ToList();
            }

            if (model.GenresIDs.Any())
            {
                movies = movies.Where(x => x.Equals(model.GenresIDs)).ToList();
            }


            if (!movies.Any()) return NoContent();

            var responseViewModel = new List<MoviesGetResponseViewModel>();

            foreach (var movie in movies)
            {
                responseViewModel.Add(new MoviesGetResponseViewModel()
                {
                    Image = movie.Image,
                    Title = movie.Title,
                    Release_Year = movie.Release_Year,
                    Ranking = movie.Ranking,
                   //GenresNames = movie. //.Split('\u002C'),
                });

            }
            return Ok(responseViewModel);

        }

        [HttpGet]
        [Route("movies")]
        public IActionResult GetDetailMovies()
        {
            //definir una variable que contiene todas las movieseries del contexto
            var movies = _context.MovieSeries.ToList();
            
            //si no hay objetos entonces devolver nocontent
            if (!movies.Any()) return NoContent();
            
            //si no se cumple la condicion anterior entonces crear un objeto con la estructra del viewmodel
            var responseViewModel = new List<MoviesGetResponseViewModel>();

            //recorrer con un ciclo el objeto con la lista de movies y extraer solo los datos necesarios
            foreach (var movie in movies)
            {
                responseViewModel.Add(new MoviesGetResponseViewModel()
                {
                    Image = movie.Image,
                    Title = movie.Title,
                    Release_Year = movie.Release_Year,
                    Ranking = movie.Ranking,
                });
            }

            //se retorna solo el modelo de vista
            return Ok(responseViewModel);
        }

        [HttpGet]
        [Route("all_movieSeries")]
        public IActionResult GetAllMovieSeries() {
            //MovieSeriesResponseViewModel
            //retornamos un mensaje OK que contiene una lista de las movieseries del contexto actual
            //return Ok(_context.MovieSeries.ToList());

            //var moviess = _context.Genres.Name;

            var movies = _context.MovieSeries.Include(x => x.Characters).ToList();
            var responseViewModel = new List<MovieSeriesResponseViewModel>();

            //recorrer con un ciclo el objeto con la lista de movies y extraer solo los datos necesarios
            foreach (var movie in movies)
            {
                responseViewModel.Add(new MovieSeriesResponseViewModel()
                {
                    Image = movie.Image,
                    Title = movie.Title,
                    Release_Year = movie.Release_Year,
                    Ranking = movie.Ranking,
                    //Genres_name = movie.Genres.Name,
                    Characters = movie.Characters.Select(x => x.Name).ToList()
                    //RelatedMovies = character.MovieSeries.Select(x => x.Title).ToList()
                });
            }

            //se retorna solo el modelo de vista
            return Ok(responseViewModel);
        }

        [HttpGet]
        [Route("movieSeries_details")]
        public async Task<IActionResult> movieSeriesDetails()
        {
            var movies = _context.MovieSeries.Include(x => x.Characters).ToList();
            //var moviess = _context.Genres.Name;
            var responseViewModel = new List<MovieSeriesDetailsResponseViewModel>();

            //recorrer con un ciclo el objeto con la lista de movies y extraer solo los datos necesarios
            foreach (var movie in movies)
            {
                //if(movie.Genres.ID != null)
                //{
                //    responseViewModel.Add(new MovieSeriesDetailsResponseViewModel()
                //    {
                //        ID = movie.ID,
                //        Image = movie.Image,
                //        Title = movie.Title,
                //        Release_Year = movie.Release_Year,
                //        Ranking = movie.Ranking,
                //        Genres_name = movie.Genres.Name,// <---
                //        Characters = movie.Characters.Select(x => x.Name).ToList()
                //if(ge)? Genres_name = movie.Genres.Name : movie.Genres.Name = "no posee" ,// <---
                //    });
                //}


                responseViewModel.Add(new MovieSeriesDetailsResponseViewModel()
                {
                    ID = movie.ID,
                    Image = movie.Image,
                    Title = movie.Title,
                    Release_Year = movie.Release_Year,
                    Ranking = movie.Ranking,
                    
                    //Genres_name = movie.Genres.Name is null ? "no posee" : movie.Genres.Name,// <---
                    
                    Characters = movie.Characters.Select(x => x.Name).ToList()
                });
                

            }

            //se retorna solo el modelo de vista
            return Ok(responseViewModel);
        }


        [HttpPost]
        [Route("create_movieSeries")]
        public async Task<IActionResult> PostMovieSeries(MovieSeriePostRequestViewModel movieSerie)
        {

            MovieSerie movie = new MovieSerie
            {
                Image = movieSerie.Image,
                Title = movieSerie.Title,
                Release_Year = movieSerie.Release_Year,
                Ranking = movieSerie.Ranking
            }; 
            
            _movieSeriesRepository.Add(movie);
            _context.SaveChanges();
            return Ok(_context.MovieSeries.ToList());
        }

        [HttpPut]
        [Route("update_movieSerie")]
        public IActionResult PutMovieSeries(MovieSeriePutRequestViewModel movieSerie)
        {
            //primero hay que saber si la serie o pelicula existe en el contexto o base de datos
            if (_context.MovieSeries.FirstOrDefault(x => x.ID == movieSerie.ID) == null) 
                //si no existe tal objeto entonces se devuelve un error 400 con
                return BadRequest("The Movie/serie does not exists.");
            //entonces si el objeto existe se debe generar un  objeto auxiliar para guardar la nueva serie
            var auxMovie = _context.MovieSeries.Find(movieSerie.ID);

            //se guardan los parametros de las peliculas
            auxMovie.Image = movieSerie.Image;
            auxMovie.Title = movieSerie.Title;
            auxMovie.Release_Year = movieSerie.Release_Year;
            auxMovie.Ranking = movieSerie.Ranking;

            //se guardan los cambios
            _context.SaveChanges();

            //se retorna una lista con el objeto modificado
            return Ok(_context.MovieSeries.ToList());
        }

        [HttpDelete]
        [Route("delete_movieSeries/{id}")]

        public IActionResult DeleteCharact(int id)
        {
            if (_context.MovieSeries.FirstOrDefault(x => x.ID == id) == null) 
                return BadRequest("La película o serie no existe.");
            var auxMovie= _context.MovieSeries.Find(id);
            _context.MovieSeries.Remove(auxMovie);
            _context.SaveChanges();
            return Ok(_context.MovieSeries.ToList());
        }
    }
}
