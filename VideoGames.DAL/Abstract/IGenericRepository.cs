﻿using System.Linq.Expressions;
using VideoGames.DAL.Entities.Abstract;

namespace VideoGames.DAL.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity?> GetAsync(int id);
    }
}
