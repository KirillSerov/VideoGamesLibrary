using System.ComponentModel.DataAnnotations;
using VideoGames.Api.Models.Abstract;

namespace VideoGames.Api.Models.Models
{
    public class GameModel : BaseModel
    {
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "Длина должна быть от 1 до 100")]
        public string Title { get; set; } = null!;

        [Required]
        public IEnumerable<GenreModel> Genres { get; set; } = null!;

        [Required]
        public CreaterModel Creater { get; set; } = null!;
    }
}
