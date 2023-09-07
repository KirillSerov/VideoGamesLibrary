namespace VideoGames.BLL.Domain.Abstract
{
    public abstract class BaseResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
