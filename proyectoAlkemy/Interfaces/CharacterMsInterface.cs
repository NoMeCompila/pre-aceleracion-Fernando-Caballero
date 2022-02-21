//interfaz para desacoplar clases
//importar los modelos de entidades
using proyectoAlkemy.Models;

namespace proyectoAlkemy.Interfaces
{
    //declarar como interfaz y cambiar nombre con la I delante por convencion
    public interface ICharacterMsRepository
    {
        //agregar las funcionalidades genericas
        List<CharactersMS> GetAllEntities();

        CharactersMS GetEntity(int id);

        CharactersMS Add(CharactersMS entity);

        void Delete(int id);

        CharactersMS Update(CharactersMS entity);
    }
}
