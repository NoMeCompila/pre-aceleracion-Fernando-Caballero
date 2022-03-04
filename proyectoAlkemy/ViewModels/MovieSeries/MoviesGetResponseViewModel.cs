namespace proyectoAlkemy.ViewModels.MovieSeries
{
    //view model de salida
    public class MoviesGetResponseViewModel
    {
        public string? Image { get; set; }
        public string? Title { get; set; }
        public DateTime Release_Year { get; set; }
        public int Ranking { get; set; }
        //public string? GenresNames { get; set; }
    }
}
