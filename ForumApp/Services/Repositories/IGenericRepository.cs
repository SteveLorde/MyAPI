using System.Linq.Expressions;
using MyAPI.Data.DTOs;

namespace MyAPI.ForumApp.Services.Repositories;

public interface IGenericRepository<T> where T : class
{
        public Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes);
        public Task<T?> Get(string entityid, params Expression<Func<T, object>>[] includes);
        public Task<bool> Add(TDTO entitydto);
        public Task<bool> AddDirect(T entity);
        public Task<bool> Update(TDTO entitydto);
        public Task<bool> Remove(string entityid);
}