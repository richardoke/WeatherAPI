﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeatherAPI.Entities;

namespace WeatherAPI.Repository.Generic
{
    public interface IGenericRepository<TEntity>
        where TEntity : Entity {

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> where);
       Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> Query();
        Task Create(TEntity entity);
        Task Add(TEntity entity);
        Task AddRange(List<TEntity> entity);
        Task Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        Task Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task<int> Count(Guid Id);
        Task SoftDelete(TEntity entity);
        Task<bool> Save();
    }
}
