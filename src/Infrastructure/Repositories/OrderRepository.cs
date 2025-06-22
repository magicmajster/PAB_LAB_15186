using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context) => _context = context;

    public async Task<Order?> GetByIdAsync(int id) => await _context.Orders.FindAsync(id);
    public async Task<IReadOnlyList<Order>> GetAllAsync() => await _context.Orders.ToListAsync();
    public async Task<Order> AddAsync(Order entity)
    {
        await _context.Orders.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task UpdateAsync(Order entity)
    {
        _context.Orders.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Order entity)
    {
        _context.Orders.Remove(entity);
        await _context.SaveChangesAsync();
    }
}