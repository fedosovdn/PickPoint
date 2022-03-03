using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickPoint.Domain;

namespace PickPoint.Persistence.Configurations;

public class PostomatConfiguration : IEntityTypeConfiguration<Postomat>
{
    public void Configure(EntityTypeBuilder<Postomat> builder)
    {
    }
}