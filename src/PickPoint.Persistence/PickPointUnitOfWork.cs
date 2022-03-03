using PickPoint.Domain;
using PickPoint.Persistence.Repositories;

namespace PickPoint.Persistence;

internal sealed class PickPointUnitOfWork : BaseUnitOfWork, IPickPointUnitOfWork 
{
    public PickPointUnitOfWork(PickPointDbContext context) : base(context)
    {
    }

    public OrderRepository OrderRepository => new(Context.Set<Order>());
    public PostomatRepository PostomatRepository => new(Context.Set<Postomat>());
}