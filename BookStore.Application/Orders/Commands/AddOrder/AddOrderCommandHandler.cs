using AutoMapper;
using BookStore.Application.Metrics;
using BookStore.Data.Books;
using BookStore.Data.Orders;
using BookStore.Models;
using MediatR;

namespace BookStore.Application.Orders.Commands.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;
        private readonly BookStoreMetrics _meters;
        private readonly IMapper _mapper;

        public AddOrderCommandHandler(IOrderRepository orderRepository, IBookRepository bookRepository,
                                      BookStoreMetrics meters, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
            _meters = meters;
            _mapper = mapper;
        }

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
            _meters.RecordNumberOfBooks(orderBooks.Count);

            return Unit.Value;
        }

        private void AddMetrics(Order order)
        {
            _meters.RecordOrderTotalPrice(order.TotalAmount);
            _meters.IncreaseTotalOrders(order.City!);
        }
    }
}
