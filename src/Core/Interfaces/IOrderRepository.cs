using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(int id);
    Task<IReadOnlyList<Order>> GetAllAsync();
    Task<Order> AddAsync(Order entity);
    Task UpdateAsync(Order entity);
    Task DeleteAsync(Order entity);
}