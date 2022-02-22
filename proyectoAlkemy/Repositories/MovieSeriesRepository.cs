//librerias importadas
using proyectoAlkemy.Models;
using proyectoAlkemy.Contexts;
using proyectoAlkemy.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        /*
        public MovieSerie? GetMovieByID(int id) 
        {
            return DbSet.Include(x => x.Genres).FirstOrDefault(x => x.ID == id);    
        }*/

    }
}
