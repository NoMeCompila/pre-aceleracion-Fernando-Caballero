namespace proyectoAlkemy.Models
{
    public class MovieSerie
    {
        //propiedades primitivas
        public int Id { get; set; }
        public string image { get; set; }
        public string title { get; set; } 
        public DateTime release_year { get; set; }
        public int ranking { get; set; }
        //falta la relacion con la tabla auxiliar
        //propiedades de navegacion
        //una serie o pelicula tiene varios personajes
        public ICollection<CharactersMS> Characters { get; set; } = new List<CharactersMS>();
        //una serei o pelicula tiene un genero
        public Genres Genres { get; set; }
    }
}
