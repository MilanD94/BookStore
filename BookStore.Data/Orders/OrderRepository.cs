using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Orders
{
    public class OrderRepository(ApiDbContext apiDbContext) : IOrderRepository
    {
        private readonly ApiDbContext _apiDbContext = apiDbContext;

        public Task<List<Order>> GetAllOrders()
        {
            return Task.Run(() => GetQueryable().ToList())!;
        }

        public Task<List<Order>> GetOrdersByBookId(Guid bookId)
        {
            var orders = _apiDbContext.Orders
                .Include(x => x.Books)
                .Where(x => x.Books!
                .Any(x => x.Id == bookId))
                .ToList();

            return Task.Run(() => orders);
        }

        public Task<Order> AddOrder(Order book)
        {
            var result = _apiDbContext.Orders?.Add(book)!;

            _apiDbContext.SaveChangesAsync();

            return Task.Run(() => result.Entity);
        }

        public Task<Order> GetOrderById(Guid? id)
        {
            var order = _apiDbContext.Orders?.FirstOrDefault(x => x.Id == id);

            return Task.Run(() => order)!;
        }

        public Task<Order> UpdateOrder(Order order)
        {
            var result = _apiDbContext.Orders?.Update(order);
            _apiDbContext.SaveChangesAsync();

            return Task.Run(() => result!.Entity)!;
        }

        public async Task DeleteOrder(Order order)
        {
            _apiDbContext.Orders?.Remove(order);
            await _apiDbContext.SaveChangesAsync();
        }


        private IQueryable<Order?> GetQueryable()
        {
            var orders = _apiDbContext.Orders.Include(x => x.Books);

            return orders;
        }
    }
}