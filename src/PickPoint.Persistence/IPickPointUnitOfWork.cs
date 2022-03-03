using PickPoint.Persistence.Repositories;

namespace PickPoint.Persistence;

public interface IPickPointUnitOfWork : IUnitOfWork
{
    public OrderRepository OrderRepository { get; }

    public PostomatRepository PostomatRepository { get; }
}