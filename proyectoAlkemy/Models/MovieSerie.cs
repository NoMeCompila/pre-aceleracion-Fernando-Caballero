using System.ComponentModel.DataAnnotations;
namespace proyectoAlkemy.Models
{
    public class MovieSerie
    {
        public int ID { get; set; }
        [Display(Name = "Imagen")]
        public string Image { get; set; }
        [Required]
        [Display(Name = "Título")]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Año de lanzamiento")]
        [DataType(DataType.Date)]
        public DateTime Release_Year { get; set; }
        [Display(Name = "Valoración")]
        public int Ranking { get; set; }
      
        public List<Characters>? Characters { get; set; }
        
        public Genres? Genres { get; set; }
    }
}
