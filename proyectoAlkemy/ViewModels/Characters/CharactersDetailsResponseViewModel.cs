namespace proyectoAlkemy.ViewModels.Characters
{
    public class CharactersDetailsResponseViewModel
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string Lore { get; set; }
        public List<string>? RelatedMovies { get; set; } = new List<string>();
    }
}
