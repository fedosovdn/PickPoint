namespace PickPoint.Persistence;

public sealed class DbInitializer
{
    public  void Seed(PickPointDbContext context)
    {
        context.Migrate();

        context.Database.EnsureCreated();
    }
}