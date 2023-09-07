using VideoGames.BLL.Entities.Abstract;

namespace VideoGames.BLL.Domain.DTO
{
    public class CreaterDTO : BaseDTO
    {
        public string Title { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
