namespace PickPoint.Persistence;

internal class BaseUnitOfWork : IUnitOfWork
{
    protected readonly PickPointDbContext Context;
    
    protected BaseUnitOfWork(PickPointDbContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public int SaveChanges()
    {
        return Context.SaveChanges();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return Context.SaveChangesAsync(cancellationToken);
    }
}