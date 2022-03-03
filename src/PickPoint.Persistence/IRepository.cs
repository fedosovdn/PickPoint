namespace PickPoint.Persistence;

public interface IRepository<TEntity> : IQueryable<TEntity> where TEntity : class
{
    void Add(TEntity entity);

    void AddRange(IEnumerable<TEntity> entities);

    void Attach(TEntity entity);

    TEntity? Find(params object[] keyValues);

    TEntity Remove(TEntity entity);

    bool Any(Func<TEntity, bool> predicate);

    void RemoveRange(IEnumerable<TEntity> entities);

    IQueryable<TEntity> GetAll();
}