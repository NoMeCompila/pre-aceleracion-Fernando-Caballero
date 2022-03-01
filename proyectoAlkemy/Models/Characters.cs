using System.ComponentModel.DataAnnotations;
namespace proyectoAlkemy.Models
{
    public class Characters
    {

        public int ID { get; set; }
        [Required]
        public string Image{ get; set; }
        
        [Required]
        [MaxLength(35)]
        [RegularExpression("^[A-Za-z ]+$")]
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

        public List<MovieSerie>? MovieSeries { get; set; }

    }
}
