using System.Linq.Expressions;
using MyAPI.Data.DTOs;
using MyAPI.ForumApp.Data.DTOs;

namespace MyAPI.ForumApp.Services.Repositories;

public interface IGenericRepository<T> where T : class
{
        public Task<List<T>> GetAll<TKey>(Expression<Func<T, TKey>> keySelector,params Expression<Func<T, object>>[] includes);
        public Task<T?> Get(string entityid, params Expression<Func<T, object>>[] includes);
        public Task<bool> Add(BaseDTO entitydto);
        public Task<bool> AddDirect(T entity);
        public Task<bool> Update(BaseDTO entitydto);
        public Task<bool> Remove(string entityid);
}