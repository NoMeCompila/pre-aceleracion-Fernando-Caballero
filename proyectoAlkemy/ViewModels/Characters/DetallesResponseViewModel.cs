using proyectoAlkemy.Models;
using proyectoAlkemy.ViewModels.MovieSeries;

namespace proyectoAlkemy.ViewModels.Characters
{
    public class DetallesResponseViewModel
    {   
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string Lore { get; set; }
        public List<int> MovieSeriesID { get; set; }
    }
}
