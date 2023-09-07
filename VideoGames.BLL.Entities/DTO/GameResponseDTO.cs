using VideoGames.BLL.Domain.Abstract;

namespace VideoGames.BLL.Domain.DTO
{
    public class GameResponseDTO : BaseResponseDTO
    {
        public CreaterResponseDTO Creater { get; set; } = null!;
        public IEnumerable<GenreResponseDTO> Genres { get; set; } = null!;
    }
}
