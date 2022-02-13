using System.ComponentModel.DataAnnotations;
namespace proyectoAlkemy.Models
{
    public class Genres
    {
        //propiedades primitivas
        public int ID { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(35)]
        public string Name { get; set; }
        
        [Required]
        public string Image { get; set; }

        [Required]
        public string Asociated_Movie_Serie { get; set; }

        //pripiedades de navegacion
        //un genero tiene varias peliculas asociadas
        public ICollection<MovieSerie> Movies { get; set; }
    }
}
