using Core.Entities;
using Core.Interfaces;
using HotChocolate.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebServices.GraphQL;

public class Query
{
    [UseFiltering]
    public async Task<IEnumerable<Product>> GetProducts(
        [Service] IProductRepository productRepository)
        => await productRepository.GetAllAsync();

    public async Task<Product?> GetProduct(
        int id,
        [Service] IProductRepository productRepository)
        => await productRepository.GetByIdAsync(id);
}