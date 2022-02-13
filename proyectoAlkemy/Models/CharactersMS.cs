using System.ComponentModel.DataAnnotations;
namespace proyectoAlkemy.Models
{
    //tabla auxiliar para representat la relacion de muchos a muchos
    public class CharactersMS
    {
        
        public int ID { get; set; } //id para cada relacion
        public int CharactersID{ get; set; } // identificador del personaje
        public Characters Character { get; set; } //relacion con la tabla Characters

        public int Movie_SerieID { get; set; } // identificador de la serie o pelicula
        public MovieSerie MovieSerie { get; set; } // relacion con la tabla MovieSeries

        // la tabla se relaciona con varias series/peliculas y varios personajes
        
    }
}
