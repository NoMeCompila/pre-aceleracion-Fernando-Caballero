//librerias importadas
using proyectoAlkemy.Models;
using proyectoAlkemy.Contexts;
using proyectoAlkemy.Interfaces;

namespace proyectoAlkemy.Repositories
{
    //herencia del repositorio base
    //declaración de la entidad, contexto e interfaz
    public class MovieSeriesRepository : BaseRepository<MovieSerie, DisneyContext>, IMovieSeriesRepository
    {
        //inyeccion por constructor del contexto 
        public MovieSeriesRepository(DisneyContext context) : base(context)
        {

        }

        
    }
}
