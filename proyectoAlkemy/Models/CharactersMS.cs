namespace proyectoAlkemy.Models
{
    public class CharactersMS
    {
        public int id { get; set; }
        public int characters_ms{ get; set; }
        public int movie_serie { get; set; }


        // la tabla se relaciona con varias series/peliculas y varios personajes
        public ICollection<MovieSerie> movies_serie { get;set; }
        public ICollection<Characters> Characters {get;set; }
    }
}
