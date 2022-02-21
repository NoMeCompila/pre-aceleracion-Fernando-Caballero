//librerias importadas
using proyectoAlkemy.Models;
using proyectoAlkemy.Contexts;
using proyectoAlkemy.Interfaces;

namespace proyectoAlkemy.Repositories
{
    //herencia del repositorio base y declaración de la entidad, contexto e interfaz
    public class CharacterMsRepository : BaseRepository<CharactersMS, DisneyContext>, ICharacterMsRepository
    {
        //inyeccion por constructor del contexto 
        public CharacterMsRepository(DisneyContext context) : base(context)
        {

        }

        //funcionalidades adicionales opcionales
    }
}
