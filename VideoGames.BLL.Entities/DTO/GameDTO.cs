using VideoGames.BLL.Entities.Abstract;

namespace VideoGames.BLL.Domain.DTO
{
    public class GameDTO : BaseDTO
    {
        public string Title { get; set; } = null!;
        public CreaterDTO Creater { get; set; } = null!;
        public IEnumerable<GenreDTO> Genres { get; set; } = null!;

    }
}
