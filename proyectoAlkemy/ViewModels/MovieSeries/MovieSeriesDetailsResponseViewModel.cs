namespace proyectoAlkemy.ViewModels.MovieSeries
{
    public class MovieSeriesDetailsResponseViewModel
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime Release_Year { get; set; }
        public int Ranking { get; set; }
        //public string Genres_name { get; set; }
        public List<string> Characters { get; set; } = new List<string>();
    }
}
