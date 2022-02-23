namespace proyectoAlkemy.ViewModels.Characters
{
    //view model de salida que se ve reflejado luego de la busquda en formato JSON
    public class CharacterResponsetDetailViewModel
    {
        public string? Image { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public float? Weight { get; set; }
        public string? Lore { get; set; }
        public List<int> MovieSeriesID { get; set; } = new List<int>();
    }
}