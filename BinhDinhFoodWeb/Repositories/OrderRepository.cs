using BinhDinhFood.Intefaces;
using BinhDinhFood.Models;
using BinhDinhFood.Models.Entities;

namespace BinhDinhFood.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(BinhDinhFoodDbContext context) : base(context)
    {

    }
    public async Task UpdatePaymentState(int orderId)
    {
        var order = await _context.Orders.FindAsync(orderId);
        order.PaidState = true;
        await _context.SaveChangesAsync();
    }
}
