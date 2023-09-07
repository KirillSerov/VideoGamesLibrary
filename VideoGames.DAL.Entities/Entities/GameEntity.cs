using VideoGames.DAL.Entities.Abstract;

namespace VideoGames.DAL.Entities.Entities
{
    public class GameEntity:BaseEntity
    {
        public string Title { get; set; } = null!;
        public CreaterEntity Creater { get; set; } = null!;
        public IEnumerable<GenreEntity> Genres { get; set; } = null!;
    }
}
