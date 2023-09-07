using VideoGames.Api.Models.Abstract;

namespace VideoGames.Api.Models.Models
{
    public class GameRequest : BaseRequest
    {
        public int CreaterId { get; set; }

        public IEnumerable<int> GenresID { get; set; } = null!;
    }
}
