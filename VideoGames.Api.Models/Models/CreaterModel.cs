using System.ComponentModel.DataAnnotations;
using VideoGames.Api.Models.Abstract;

namespace VideoGames.Api.Models.Models
{
    public class CreaterModel : BaseModel
    {
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "Длина должна быть от 1 до 100")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "Длина должна быть от 1 до 100")]
        public string Country { get; set; } = null!;
    }
}
