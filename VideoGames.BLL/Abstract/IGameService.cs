using VideoGames.BLL.Domain.DTO;

namespace VideoGames.BLL.Abstract
{
    public interface IGameService : IService<GameDTO>
    {
        public Task<IEnumerable<GameDTO>> GetByGenreAsync(int genreId);
    }
}
