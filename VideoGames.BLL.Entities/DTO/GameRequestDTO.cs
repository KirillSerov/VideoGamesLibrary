using VideoGames.BLL.Domain.Abstract;

namespace VideoGames.BLL.Domain.DTO
{
    public class GameRequestDTO: BaseRequestDTO
    {
        public int Id { get; set; }
        public int CreaterId { get; set; }
        public IEnumerable<int> GenresID { get; set; } = null!;
    }
}
