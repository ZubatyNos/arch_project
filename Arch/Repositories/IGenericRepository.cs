using System.Linq.Expressions;

namespace ArchProject.Repositories;

public interface IGenericRepository<T> where T : class
{
    public T? GetById(int id);
    public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
    public IEnumerable<T> Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
    public void Add(T entity);
    public void AddRange(IEnumerable<T> entities);
    public void Remove(T entity);
    public void RemoveRange(IEnumerable<T> entities);
    public void Update(T entity);
}