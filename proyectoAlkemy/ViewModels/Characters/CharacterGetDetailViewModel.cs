using proyectoAlkemy.Models;
namespace proyectoAlkemy.ViewModels.Characters
{
    public class CharacterGetDetailViewModel
    {
        public string? Image { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public float? Weight { get; set; }
        public string? Lore { get; set; }
        public List<MovieSerie> MovieSeries { get; set; } = new List<MovieSerie>();
        //public List<int> MovieSeriesID { get; set; } = new List<int>();
    }
}
