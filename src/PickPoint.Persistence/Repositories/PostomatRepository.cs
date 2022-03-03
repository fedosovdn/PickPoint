using Microsoft.EntityFrameworkCore;
using PickPoint.Domain;

namespace PickPoint.Persistence.Repositories;

public class PostomatRepository : EfRepository<Postomat>
{
    public PostomatRepository(DbSet<Postomat> dbSet) : base(dbSet)
    {
    }
}