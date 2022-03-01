using System.ComponentModel.DataAnnotations;

namespace proyectoAlkemy.ViewModels.MovieSeries
{
    public class MovieSeriePostRequestViewModel
    {
        [Required]
        public string? Image { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Release_Year { get; set; }

        //[Display(Name = "Valoración")]
        [Range(0,5)]
        public int Ranking { get; set; }
    }
}
