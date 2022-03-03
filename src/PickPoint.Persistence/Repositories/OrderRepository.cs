using Microsoft.EntityFrameworkCore;
using PickPoint.Domain;

namespace PickPoint.Persistence.Repositories;

public class OrderRepository : EfRepository<Order>
{
    public OrderRepository(DbSet<Order> dbSet) : base(dbSet)
    {
    }

    public IQueryable<Order> GetAllIncluded()
    {
        return GetAll().Include(order => order.Postomat);
    }
}