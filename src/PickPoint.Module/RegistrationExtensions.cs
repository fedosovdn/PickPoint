using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PickPoint.Application;
using PickPoint.Application.OrderHandlers;
using PickPoint.Persistence;

namespace PickPoint.Module;

public static class RegistrationExtensions
{
    public static IServiceCollection AddPickPointModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IPickPointUnitOfWork, PickPointUnitOfWork>();
        services.AddSingleton(new DbInitializer());

        string? connectionString = configuration.GetConnectionString("PickPointDbContext");
        services.AddDbContext<PickPointDbContext>(
            options => options.UseSqlServer(connectionString)
        );

        services.AddMediatR(typeof(OrderInfoRequestHandler).Assembly);

        return services;
    }
}