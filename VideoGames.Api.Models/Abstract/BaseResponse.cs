namespace VideoGames.Api.Models.Abstract
{
    public abstract class BaseResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

    }
}
