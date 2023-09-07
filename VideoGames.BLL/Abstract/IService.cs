using VideoGames.BLL.Entities.Abstract;

namespace VideoGames.BLL.Abstract
{
    public interface IService<TEntity> where TEntity : BaseDTO
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity?> GetAsync(int id);
    }
}
