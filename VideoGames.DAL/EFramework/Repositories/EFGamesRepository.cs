using Microsoft.EntityFrameworkCore;
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
    }
}
