using proyectoAlkemy.Models;
namespace proyectoAlkemy.ViewModels.MovieSeries
{
    public class MovieSerieDetailViewmodel
    {
        public string? Image { get; set; }
        public string? Title { get; set; }
        public DateTime? Release_Year { get; set; }
        public int? Ranking { get; set; }
        public Genres? Genre{ get; set; }
    }
}
