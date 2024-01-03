using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data.DTOs;
using MyAPI.ForumApp.Data;

namespace MyAPI.ForumApp.Services.Repositories;

class GenericRepository<T> : IGenericRepository<T> where T : class, new()
{
    
    public ForumAppDbContext _db;
    public IMapper _mapper;
    public  IWebHostEnvironment _hostenv;

    public GenericRepository(ForumAppDbContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment)
    {
        _db = db;
        _mapper = mapper;
        _hostenv = hostingEnvironment;
    }

    public async Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes)
    { 
        IQueryable<T> query = _db.Set<T>().AsQueryable();
        
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return await query.ToListAsync();
    }
    
    public async Task<T?> Get(string entityid, params Expression<Func<T, object>>[] includes)
    {
        var query = _db.Set<T>().AsQueryable();
        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }
        return await query.FirstAsync(entity => EF.Property<Guid>(entity, "Id") == Guid.Parse(entityid));
    }

    public async Task<bool> Add(TDTO entitydto)
    {
        entitydto.date = DateTime.Now;
        T newentity = new T();
        newentity = _mapper.Map<T>(entitydto);
        await _db.Set<T>().AddAsync(newentity);
        await _db.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> AddDirect(T entity)
    {
        await _db.Set<T>().AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> Update(TDTO entitydao)
    {
        var selectedentity = await _db.Set<T>().FindAsync(Guid.Parse(entitydao.id));
        selectedentity = _mapper.Map<T>(entitydao);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Remove(string entityid)
    {
        var selectedentity = await _db.Set<T>().FindAsync(Guid.Parse(entityid));
        _db.Set<T>().Remove(selectedentity);
        return true;
    }
}