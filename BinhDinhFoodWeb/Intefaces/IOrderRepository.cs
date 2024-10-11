using BinhDinhFood.Models;

namespace BinhDinhFoodWeb.Intefaces;

public interface IOrderRepository : IRepository<Order>
{
    public Task UpdatePaymentState(int orderId);
}
