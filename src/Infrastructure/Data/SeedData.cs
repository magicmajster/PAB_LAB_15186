using Core.Entities;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (!context.Products.Any())
        {
            var products = new List<Product>
            {
                new() { Name = "Laptop", Price = 999.99m, Description = "High performance laptop" },
                new() { Name = "Phone", Price = 699.99m, Description = "Smartphone with great camera" },
                new() { Name = "Tablet", Price = 399.99m, Description = "Portable tablet device" }
            };

            await context.Products.AddRangeAsync(products);
        }

        if (!context.Users.Any())
        {
            var users = new List<User>
            {
                new() { Username = "admin", Email = "admin@example.com", PasswordHash = "admin123", Role = "Admin" },
                new() { Username = "user", Email = "user@example.com", PasswordHash = "user123", Role = "User" }
            };

            await context.Users.AddRangeAsync(users);
        }

        await context.SaveChangesAsync();
    }
}
