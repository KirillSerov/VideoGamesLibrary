using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoGames.BLL.Abstract;
using VideoGames.BLL.Domain.DTO;
using VideoGames.DAL.Abstract;
using VideoGames.DAL.Entities.Entities;

namespace VideoGames.BLL.Services
{
    public class GameService : IGameService
    {
        private readonly IGenericRepository<GameEntity> _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IGenericRepository<GameEntity> repository, IMapper mapper)
        {
            _gameRepository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(GameDTO game)
        {
            GameEntity entity = _mapper.Map<GameEntity>(game);
            await _gameRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _gameRepository.DeleteAsync(id);
        }

        public async Task<IQueryable<GameDTO>> GetAllAsync()
        {
            IQueryable<GameEntity> entity = await _gameRepository.GetAllAsync();
            return _mapper.Map<IQueryable<GameDTO>>(entity);
        }

        public async Task<GameDTO?> GetAsync(int id)
        {
            GameEntity? entity = await _gameRepository.GetAsync(id);
            return _mapper.Map<GameDTO?>(entity);
        }

        public async Task<IEnumerable<GameDTO>> GetByGenreAsync(int genreId)
        {
            IQueryable<GameEntity> entities = await _gameRepository.GetAllAsync();
            var result = await entities.Where(game => game.Genres.FirstOrDefault(genre=>genre.Id == genreId) != null).ToListAsync();
            return _mapper.Map<IEnumerable<GameDTO>>(result);
        }

        public async Task UpdateAsync(GameDTO game)
        {
            GameEntity entity = _mapper.Map<GameEntity>(game);
            await _gameRepository.UpdateAsync(entity);
        }
    }
}
