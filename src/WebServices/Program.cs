using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WebServices.GraphQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("InMem"));

builder.Services.AddScoped<Core.Interfaces.IProductRepository, Infrastructure.Repositories.ProductRepository>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddFiltering();

var app = builder.Build();

app.MapGraphQL();

app.Run();