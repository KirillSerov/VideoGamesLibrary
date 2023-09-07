using VideoGames.BLL.Domain.Abstract;

namespace VideoGames.BLL.Domain.DTO
{
    public class CreaterRequestDTO : BaseRequestDTO
    {
        public string Country { get; set; } = null!;
    }
}
