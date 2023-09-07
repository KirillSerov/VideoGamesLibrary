using Microsoft.EntityFrameworkCore;
using VideoGames.DAL.Abstract;
using VideoGames.DAL.EFramework.Context;
using VideoGames.DAL.Entities.Abstract;

namespace VideoGames.DAL.EFramework.Repositories
{
    public abstract class BaseEFRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected EFContext _context;

        public BaseEFRepository(EFContext context)
        {
            _context = context;
        }

        public async virtual Task<bool> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            int count = await _context.SaveChangesAsync();

            if (count > 0)
                return true;

            return false;
        }

        public async virtual Task<bool> DeleteAsync(int id)
        {
            TEntity? entity = _context.Set<TEntity>().Find(id);

            if (entity == null)
                return false;

            _context.Set<TEntity>().Remove(entity);
            int count = await _context.SaveChangesAsync();
            
            if(count == 0)
                return false;

            return true;
        }

        public async virtual Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => _context.Set<TEntity>());
        }

        public async virtual Task<TEntity?> GetAsync(int id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async virtual Task<bool> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            int count = await _context.SaveChangesAsync();

            if (count == 0)
                return false;

            return true;
        }
    }
}
