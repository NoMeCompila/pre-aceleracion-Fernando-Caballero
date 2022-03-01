using Microsoft.EntityFrameworkCore;
using proyectoAlkemy.Models;
using proyectoAlkemy.Contexts;
using proyectoAlkemy.Interfaces;

namespace proyectoAlkemy.Repositories
{
    public class CharactersRepository : BaseRepository<Characters, DisneyContext>, ICharactersRepository
    {
        public CharactersRepository(DisneyContext context) : base(context)
        {

        }

        public List<Characters> getCharactersMS()
        {
            return DbSet.Include(x => x.MovieSeries).ToList();
        }

    }
}
