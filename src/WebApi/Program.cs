using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("InMem"));

// Register repositories
builder.Services.AddScoped<Core.Interfaces.IProductRepository, Infrastructure.Repositories.ProductRepository>();
builder.Services.AddScoped<Core.Interfaces.IOrderRepository, Infrastructure.Repositories.OrderRepository>();
builder.Services.AddScoped<Core.Interfaces.IUserRepository, Infrastructure.Repositories.UserRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    await SeedData.Initialize(services);
}

app.Run();