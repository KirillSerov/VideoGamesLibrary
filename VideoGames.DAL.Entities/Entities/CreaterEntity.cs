using VideoGames.DAL.Entities.Abstract;

namespace VideoGames.DAL.Entities.Entities
{
    public class CreaterEntity:BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
