using System.ComponentModel.DataAnnotations;
namespace proyectoAlkemy.Models
{
    public class Characters
    {

        //propiedades primitivas
        public int ID { get; set; }
        [Required]
        public string Image{ get; set; }
        
        [Required]
        [MaxLength(35)]
        [RegularExpression("^[A-Za-z ]+$")] // solo letras y espacios
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Edad")]
        [RegularExpression("[0-9]")]
        public int Age { get; set; }
        
        [Required]
        public float Weight { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Lore { get; set; }

        //propiedades de navegacion
        // un personaje aparece en varias series o peliculas
        public List<CharactersMS> Characters_MovieSeries { get; set; }

    }
}
