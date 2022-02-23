using proyectoAlkemy.Models;
namespace proyectoAlkemy.ViewModels.Characters
{
    //en este view model se encuentran los datos necesarios para la busqueda de un personaje sirve como input
    //a  la funcion get
    //busqueda por nombre edad y pelicula en la que aparece
    public class CharacterRequestDetailViewModel
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public List<int> MovieSeriesID { get; set; } = new List<int>();
    }
}
