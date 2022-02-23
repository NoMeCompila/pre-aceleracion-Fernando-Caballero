namespace proyectoAlkemy.ViewModels.MovieSeries
{
    //view model de entrada
    public class MoviesGetRequestViewModel
    {
        public string? Title { get; set; }
        //lista con solo con los ID de las películas
        public List<int> GenresIDs { get; set; } = new List<int>();
    }
}
