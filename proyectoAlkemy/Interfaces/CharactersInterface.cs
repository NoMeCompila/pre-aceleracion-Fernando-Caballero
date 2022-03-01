using proyectoAlkemy.Models;
namespace proyectoAlkemy.Interfaces
{
    public interface ICharactersRepository
    {
        List<Characters> GetAllEntities();

        Characters GetEntity(int id);

        Characters Add(Characters entity);

        void Delete(int id);

        Characters Update(Characters entity);
    }
}
