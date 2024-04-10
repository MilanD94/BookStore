using BookStore.Models;

namespace BookStore.Data.Orders
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> AddOrder(Order book);
        Task<Order> GetOrderById(Guid? id);
        Task<Order> UpdateOrder(Order book);
        Task<List<Order>> GetOrdersByBookId(Guid bookId);
    }
}
