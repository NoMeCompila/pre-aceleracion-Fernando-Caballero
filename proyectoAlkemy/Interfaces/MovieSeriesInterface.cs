using proyectoAlkemy.Models;

namespace proyectoAlkemy.Interfaces
{
    public interface IMovieSeriesRepository
    {
        List<MovieSerie> GetAllEntities();

        MovieSerie GetEntity(int id);

        MovieSerie Add(MovieSerie entity);

        void Delete(int id);

        MovieSerie Update(MovieSerie entity);
    }
}
