namespace proyectoAlkemy.Models
{
    public class Characters
    {

        //propiedades primitivas
        public int id { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public float weight { get; set; }
        public string lore { get; set; }
        //falta la relacion con la tabla auxiliar

        //falta la relacion con la tabla Genres

        //propiedades de navegacion
        // un personaje aparece en varias series o peliculas
        public ICollection<CharactersMS> movies_series { get; set; }

    }
}
