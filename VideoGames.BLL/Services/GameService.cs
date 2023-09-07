using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Buffers;
using VideoGames.BLL.Abstract;
using VideoGames.BLL.Domain;
using VideoGames.BLL.Domain.DTO;
using VideoGames.DAL.Abstract;
using VideoGames.DAL.Entities.Entities;

namespace VideoGames.BLL.Services
{
    public class GameService : IGameService
    {
        private readonly IGenericRepository<GameEntity> _gameRepository;
        private readonly IGenericRepository<GenreEntity> _genreRepository;
        private readonly IGenericRepository<CreaterEntity> _createRepository;
        private readonly IMapper _mapper;

        public GameService(IGenericRepository<GameEntity> repository, IGenericRepository<GenreEntity> genreRepository, IGenericRepository<CreaterEntity> createRepository, IMapper mapper)
        {
            _gameRepository = repository;
            _createRepository = createRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> AddAsync(GameRequestDTO game)
        {
            CreaterEntity? creater = await _createRepository.GetAsync(game.CreaterId);

            if (creater == null)
                return new OperationResult(OperationResult.OperationStatus.NotSuccess, "Неверно указана студия.");

            IQueryable<GenreEntity> allGenres = await _genreRepository.GetAllAsync();
            IEnumerable<GenreEntity> genres = await allGenres.Where(genre => game.GenresID.Contains(genre.Id)).ToListAsync();

            if (genres.Count() == 0)
                return new OperationResult(OperationResult.OperationStatus.NotSuccess, "Неверно указаны жанры.");

            GameEntity newEntity = new GameEntity
            {
                Title = game.Title,
                Creater = creater,
                Genres = genres
            };

            if (await _gameRepository.AddAsync(newEntity))
                return new OperationResult(OperationResult.OperationStatus.Success, "Объект добавлен в БД");

            return new OperationResult(OperationResult.OperationStatus.NotSuccess, "Не удалось добавить объект в БД.");
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            if (await _gameRepository.DeleteAsync(id))
                return new OperationResult(OperationResult.OperationStatus.Success, $"Объект с индексом {id} успешно удалён из БД.");
            return new OperationResult(OperationResult.OperationStatus.NotSuccess, $"Не удалось удалить объект с индексом {id} из БД.");
        }

        public async Task<IEnumerable<GameResponseDTO>> GetAllAsync()
        {
            IQueryable<GameEntity> entity = await _gameRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GameResponseDTO>>(await entity.ToListAsync());
        }

        public async Task<GameResponseDTO?> GetAsync(int id)
        {
            GameEntity? entity = await _gameRepository.GetAsync(id);
            return _mapper.Map<GameResponseDTO?>(entity);
        }

        public async Task<IEnumerable<GameResponseDTO>> GetByGenreAsync(int genreId)
        {
            IQueryable<GameEntity> entities = await _gameRepository.GetAllAsync();
            var result = await entities.Where(game => game.Genres.FirstOrDefault(genre => genre.Id == genreId) != null).ToListAsync();
            return _mapper.Map<IEnumerable<GameResponseDTO>>(result);
        }

        public async Task<OperationResult> UpdateAsync(GameRequestDTO game)
        {
            CreaterEntity? creater = await _createRepository.GetAsync(game.CreaterId);

            if (creater == null)
                return new OperationResult(OperationResult.OperationStatus.NotSuccess, "Неверно указана студия.");

            IQueryable<GenreEntity> allGenres = await _genreRepository.GetAllAsync();
            IEnumerable<GenreEntity> genres = await allGenres.Where(genre => game.GenresID.Contains(genre.Id)).ToListAsync();

            if (genres.Count() == 0)
                return new OperationResult(OperationResult.OperationStatus.NotSuccess, "Неверно указаны жанры.");

            GameEntity? newEntity = await _gameRepository.GetAsync(game.Id);
            if (newEntity == null)
                return new OperationResult(OperationResult.OperationStatus.NotSuccess, $"Объект с индексом {game.Id} не существует в БД.");

            newEntity.Creater = creater;
            newEntity.Genres = genres;
            newEntity.Title = game.Title;

            if (await _gameRepository.UpdateAsync(newEntity))
                return new OperationResult(OperationResult.OperationStatus.Success, $"Объект с индексом {game.Id} успешно обновлён в БД.");
            return new OperationResult(OperationResult.OperationStatus.NotSuccess, $"Не удалось удалить обновить объект с индексом {game.Id} в БД.");
        }
    }
}
