using System.ComponentModel.DataAnnotations;

namespace proyectoAlkemy.ViewModels.Characters
{
    public class CharacterPostRequestViewModel
    {
        [Required]
        public string? Image { get; set; }

        [Required]
        [MaxLength(35)]
        [RegularExpression("^[A-Za-z ]+$")]
        [Display(Name = "Nombre")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Age { get; set; }

        [Required]
        public float Weight { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string? Lore { get; set; }
    }
}
