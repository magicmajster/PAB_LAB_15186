using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BCrypt.Net;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (!context.Users.Any())
        {
           
            Console.WriteLine("Seeding admin user...");
            var adminHash = BCrypt.Net.BCrypt.HashPassword("admin123");
            Console.WriteLine($"Admin hash: {adminHash}");

            context.Users.AddRange(
                new User
                {
                    Username = "admin",
                    PasswordHash = adminHash,
                    Role = "Admin"
                },
                new User
                {
                    Username = "user",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("user123"),
                    Role = "User"
                }
            );

            await context.SaveChangesAsync();
        }

        if (!context.Products.Any())
        {
            context.Products.AddRange(
                new Product { Name = "Product 1", Price = 9.99m },
                new Product { Name = "Product 2", Price = 19.99m }
            );

            await context.SaveChangesAsync();
        }
    }
}