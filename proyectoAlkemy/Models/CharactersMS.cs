namespace proyectoAlkemy.Models
{
    public class CharactersMS
    {
        public int id { get; set; }
        public int charactersID{ get; set; }
        public Characters character { get; set; }

        public int movie_serieID { get; set; }
        public MovieSerie movieSerie { get; set; } 

        // la tabla se relaciona con varias series/peliculas y varios personajes
        //public ICollection<MovieSerie> movies_serie { get;set; }
        //public ICollection<Characters> Characters {get;set; }
    }
}
