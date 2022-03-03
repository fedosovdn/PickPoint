using System.Collections;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace PickPoint.Persistence;

public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet;

    public EfRepository(DbSet<TEntity> dbSet)
    {
        _dbSet = dbSet;
    }

    public Type ElementType => (_dbSet as IQueryable).ElementType;

    public Expression Expression => (_dbSet as IQueryable).Expression;

    public IQueryProvider Provider
    {
        get { return (_dbSet as IQueryable).Provider; }
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public bool Any(Func<TEntity, bool> predicate)
    {
        return _dbSet.Any(predicate);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        _dbSet.AddRange(entities);
    }

    public void Attach(TEntity entity)
    {
        _dbSet.Attach(entity);
    }

    public TEntity? Find(params object[] keyValues)
    {
        return _dbSet.Find(keyValues);
    }

    public IEnumerator<TEntity> GetEnumerator()
    {
        return (_dbSet as IEnumerable<TEntity>).GetEnumerator();
    }

    public TEntity Remove(TEntity entity)
    {
        var result = _dbSet.Remove(entity);
        return result.Entity;
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public virtual IQueryable<TEntity> GetAll()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (_dbSet as IEnumerable).GetEnumerator();
    }
}