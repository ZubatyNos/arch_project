using System.Linq.Expressions;
using ArchProject.Data;
using ArchProject.Repositories;
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    
    private readonly MyDbContext _dbContext;    
    private readonly DbSet<T> _dbSet;

    public GenericRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        query = includes.Aggregate(query, (current, include) => current.Include(include));

        return query.ToList();
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        query = includes.Aggregate(query, (current, include) => current.Include(include));

        return query.Where(expression).ToList();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _dbContext.SaveChanges();
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
        _dbContext.SaveChanges();
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
        _dbContext.SaveChanges();
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
        _dbContext.SaveChanges();
    }
    
    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _dbContext.SaveChanges();
    }
}