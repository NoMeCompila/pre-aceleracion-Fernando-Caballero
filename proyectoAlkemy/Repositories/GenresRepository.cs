using proyectoAlkemy.Models;
using proyectoAlkemy.Contexts;
using proyectoAlkemy.Interfaces;

namespace proyectoAlkemy.Repositories
{
    public class GenresRepository : BaseRepository<Genres, DisneyContext>, IGenresRepository 
    {
        //para que se pueda utilizar la calse base hay que inyectarla por constructor
        public GenresRepository(DisneyContext context) : base(context)
        {
            //se puede añadir lógica extra y ademas tener disponibles las funcionalidades basicas/genéricas

        }

        //aca van los metodos que necesite

        ///filtro
    }
}
