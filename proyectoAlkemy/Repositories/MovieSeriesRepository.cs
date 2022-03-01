using proyectoAlkemy.Models;
using proyectoAlkemy.Contexts;
using proyectoAlkemy.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace proyectoAlkemy.Repositories
{
    public class MovieSeriesRepository : BaseRepository<MovieSerie, DisneyContext>, IMovieSeriesRepository
    {
        public MovieSeriesRepository(DisneyContext context) : base(context)
        {

        }
    }
}
