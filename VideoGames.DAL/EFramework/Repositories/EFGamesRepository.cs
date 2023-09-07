using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VideoGames.DAL.Abstract;
using VideoGames.DAL.EFramework.Context;
using VideoGames.DAL.Entities.Entities;

namespace VideoGames.DAL.EFramework.Repositories
{
    public class EFGamesRepository : BaseEFRepository<GameEntity>
    {
        public EFGamesRepository(EFContext context) : base(context) { }

        public async override Task<IQueryable<GameEntity>> GetAllAsync()
        {
            return await Task.Run(() => _context.Games
                     .Include(g => g.Genres)
                     .Include(g => g.Creater));
        }

        public async override Task<GameEntity?> GetAsync(int id)
        {
            return await _context.Games
                .Include(g => g.Genres)
                .Include(g => g.Creater)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async override Task<bool> AddAsync(GameEntity entity)
        {
            CreaterEntity creater = await _context.Creaters.FirstOrDefaultAsync(c => c.Id == entity.Creater.Id);

            if (creater == null)
                return false;

            entity.Creater = creater!;

            IEnumerable<GenreEntity> genres = _context.Genres.AsEnumerable().Where(genre => entity.Genres.FirstOrDefault(g => g.Id == genre.Id) != null).ToList();

            if (genres.Count() == 0)
                return false;

            entity.Genres = genres;

            await _context.Games.AddAsync(entity);
            int count = await _context.SaveChangesAsync();

            if (count > 0)
                return true;

            return false;
        }
    }
}
