using proyectoAlkemy.Models;

namespace proyectoAlkemy.Interfaces
{
    public interface IGenresRepository
    {
        List<Genres> GetAllEntities();

        Genres GetEntity(int id);

        Genres Add(Genres entity);

        void Delete(int id);

        Genres Update(Genres entity);
    }
}