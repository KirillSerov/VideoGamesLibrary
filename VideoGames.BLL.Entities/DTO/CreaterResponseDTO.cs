using VideoGames.BLL.Domain.Abstract;

namespace VideoGames.BLL.Domain.DTO
{
    public class CreaterResponseDTO : BaseResponseDTO
    {
        public string Country { get; set; } = null!;
    }
}
