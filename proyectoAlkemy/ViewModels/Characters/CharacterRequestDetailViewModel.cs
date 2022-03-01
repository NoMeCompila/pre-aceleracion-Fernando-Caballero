using proyectoAlkemy.Models;
using System.ComponentModel.DataAnnotations;

namespace proyectoAlkemy.ViewModels.Characters
{
    //en este view model se encuentran los datos necesarios para la busqueda de un personaje sirve como input
    //a  la funcion get
    //busqueda por nombre edad y pelicula en la que aparece
    public class CharacterRequestDetailViewModel
    {
        [MaxLength(35)]
        [RegularExpression("^[A-Za-z ]+$")]
        public string? Name { get; set; }

        [RegularExpression("[0-9]")]
        public int? Age { get; set; }


        public List<int> MovieSeriesID { get; set; } = new List<int>();
    }
}
