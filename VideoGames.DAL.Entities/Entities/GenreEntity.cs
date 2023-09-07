using VideoGames.DAL.Entities.Abstract;

namespace VideoGames.DAL.Entities.Entities
{
    public class GenreEntity : BaseEntity
    {
        public string Title { get; set; } = null!;
        public IEnumerable<GameEntity> Games { get; set; } = null!;
    }
}
