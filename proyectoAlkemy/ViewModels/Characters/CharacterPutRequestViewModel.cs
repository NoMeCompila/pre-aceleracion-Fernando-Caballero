using System.ComponentModel.DataAnnotations;

namespace proyectoAlkemy.ViewModels.Characters
{
    public class CharacterPutRequestViewModel
    {
        public int ID { get; set; }

        [Required]
        public string? Image { get; set; }

        [Required]
        [MaxLength(35)]
        [RegularExpression("^[A-Za-z ]+$")]
        public string? Name { get; set; }

        [Required]
        [RegularExpression("[0-9]")]
        public int Age { get; set; }

        [Required]
        public float Weight { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string? Lore { get; set; }
    }
}
