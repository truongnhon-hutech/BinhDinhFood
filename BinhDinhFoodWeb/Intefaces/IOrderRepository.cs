using BinhDinhFood.Models;

namespace BinhDinhFood.Intefaces;

public interface IOrderRepository : IRepository<Order>
{
    public Task UpdatePaymentState(int orderId);
}
