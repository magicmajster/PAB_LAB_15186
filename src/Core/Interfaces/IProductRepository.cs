using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);  
    Task<IReadOnlyList<Product>> GetAllAsync();
    Task<Product> AddAsync(Product entity);
    Task UpdateAsync(Product entity);
    Task DeleteAsync(Product entity);
}