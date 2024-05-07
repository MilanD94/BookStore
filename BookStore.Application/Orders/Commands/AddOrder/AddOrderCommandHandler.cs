using BookStore.Application.Metrics;
using BookStore.Data.Books;
using BookStore.Data.Orders;
using BookStore.Models;
using MediatR;

namespace BookStore.Application.Orders.Commands.AddOrder
{
    public class AddOrderCommandHandler(IOrderRepository orderRepository, IBookRepository bookRepository,
                                  BookStoreMetrics bookStoreMetrics) : IRequestHandler<AddOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<Unit> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            decimal sum = 0;
            List<Book> orderBooks = [];

            foreach (var bookId in request.Books!)
            {
                var orderingBook = await _bookRepository.GetBookById(bookId);

                if (orderingBook is not null)
                {
                    orderBooks.Add(orderingBook);
                    sum += orderingBook.Value;
                }
            }

            var orderToAdd = new Order
            {
                Address = request.Address,
                Books = orderBooks,
                CrationDate = DateTime.UtcNow,
                City = request.City,
                CustomerName = request.CustomerName,
                Telephone = request.Telephone,
            };

            orderToAdd.SetTotalAmount(sum);

            var result = await _orderRepository.AddOrder(orderToAdd);
            AddMetrics(result);
            bookStoreMetrics.RecordNumberOfBooks(orderBooks.Count);

            return Unit.Value;
        }

        private void AddMetrics(Order order)
        {
            bookStoreMetrics.RecordOrderTotalPrice(order.TotalAmount);
            bookStoreMetrics.IncreaseTotalOrders(order.City!);
        }
    }
}
