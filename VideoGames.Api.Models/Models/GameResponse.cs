using VideoGames.Api.Models.Abstract;

namespace VideoGames.Api.Models.Models
{
    public class GameResponse:BaseResponse
    {
        public IEnumerable<GenreResponse> Genres { get; set; } = null!;

        public CreaterResponse Creater { get; set; } = null!;
    }
}
