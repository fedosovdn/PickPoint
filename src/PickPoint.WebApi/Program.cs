using FluentValidation.AspNetCore;
using PickPoint.Contracts;
using PickPoint.Module;
using PickPoint.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPickPointModule(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddFluentValidation(s => 
{ 
    s.ImplicitlyValidateChildProperties = true;
    s.ImplicitlyValidateRootCollectionElements = true;
    
    s.RegisterValidatorsFromAssemblyContaining<OrderDto>(); 
    s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

UsePersistence(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();

static void UsePersistence(IApplicationBuilder builder)
{
    ILogger<PickPointDbContext> logger = builder.ApplicationServices.GetRequiredService<ILogger<PickPointDbContext>>();

    using IServiceScope scope = builder.ApplicationServices.CreateScope();
    try
    {
        DbInitializer dbInitializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
        PickPointDbContext context = scope.ServiceProvider.GetRequiredService<PickPointDbContext>();

        dbInitializer.Seed(context);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while migrating or initializing the database");
        throw;
    }
}