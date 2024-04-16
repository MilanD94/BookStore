using BookStore.Models;

namespace BookStore.Data.Orders
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> AddOrder(Order order);
        Task<Order> GetOrderById(Guid? id);
        Task<Order> UpdateOrder(Order order);
        Task<List<Order>> GetOrdersByBookId(Guid bookId);
        Task DeleteOrder(Order order);
    }
}
