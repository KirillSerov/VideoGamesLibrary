using VideoGames.Api.Models.Abstract;

namespace VideoGames.Api.Models.Models
{
    public class CreaterRequest : BaseRequest
    {
        public string Country { get; set; } = null!;
    }
}
