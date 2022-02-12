namespace proyectoAlkemy.Models
{
    public class Genres
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string asociated_movie_serie { get; set; }

        //un genero tiene varias peliculas asociadas
        public ICollection<MovieSerie> movies { get; set; }
    }
}
