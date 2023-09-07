using VideoGames.BLL.Domain.DTO;

namespace VideoGames.BLL.Abstract
{
    public interface IGameService : IService<GameRequestDTO, GameResponseDTO>
    {
        public Task<IEnumerable<GameResponseDTO>> GetByGenreAsync(int genreId);
    }
}
