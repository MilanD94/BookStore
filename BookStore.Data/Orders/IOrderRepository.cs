using BookStore.Models;

namespace BookStore.Data.Orders
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> AddOrder(Order order);
        Task<Order> GetOrderById(Guid? id);
        Task<List<Order>> GetOrdersByBookId(Guid bookId);
    }
}
