using proyectoAlkemy.Models;
using proyectoAlkemy.Contexts;
using proyectoAlkemy.Interfaces;

namespace proyectoAlkemy.Repositories
{
    public class GenresRepository : BaseRepository<Genres, DisneyContext>, IGenresRepository 
    {
        public GenresRepository(DisneyContext context) : base(context)
        {
            
        }
    }
}
