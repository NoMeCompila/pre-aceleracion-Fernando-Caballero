//interfaz para desacoplar clases
//importar los modelos de entidades
using proyectoAlkemy.Models;

namespace proyectoAlkemy.Interfaces
{
    //declarar como interfaz y cambiar nombre con la I delante por convencion
    public interface IMovieSeriesRepository
    {
        //agregar las funcionalidades genericas
        List<MovieSerie> GetAllEntities();

        MovieSerie GetEntity(int id);

        MovieSerie Add(MovieSerie entity);

        void Delete(int id);

        MovieSerie Update(MovieSerie entity);
    }
}
