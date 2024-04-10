using BookStore.Application.DTOs;
using BookStore.Application.Metrics;
using BookStore.Data.Orders;
using BookStore.Models;
using MediatR;

namespace BookStore.Application.Orders.Commands.AddOrder
{
    public class AddOrderCommandHandler(IOrderRepository orderRepository, BookStoreMetrics meters) : IRequestHandler<AddOrderCommand, OrderRepresentation>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly BookStoreMetrics _meters = meters;

        public async Task<OrderRepresentation> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerName = request.CustomerName,
                Status = request.Status,
                Address = request.Address,  
                City = request.City,
                Telephone = request.Telephone,
                TotalAmount = request.TotalAmount,
                CrationDate = DateTime.UtcNow,
            };

            var result = await _orderRepository.AddOrder(order);

            _meters.RecordOrderTotalPrice(double.Parse(result!.TotalAmount!));
            //_meters.RecordNumberOfBooks(result.Books!.Count);
            _meters.IncreaseTotalOrders(result.City!);

            return new OrderRepresentation { };
        }
    }
}
