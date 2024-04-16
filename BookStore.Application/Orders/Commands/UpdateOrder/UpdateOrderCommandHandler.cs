using BookStore.Application.Metrics;
using BookStore.Data.Orders;
using MediatR;

namespace BookStore.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler(IOrderRepository orderRepository, BookStoreMetrics meters) : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly BookStoreMetrics _meters = meters;

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetOrderById(request.Id) ?? throw new Exception("Order is not found.");
            orderToUpdate.Telephone = request.Telephone;
            orderToUpdate.Address = request.Address;
            orderToUpdate.City = request.City;
            orderToUpdate.Status = request.Status;
            orderToUpdate.CustomerName = request.CustomerName;
            orderToUpdate.UpdateDate = DateTime.UtcNow;

            await _orderRepository.UpdateOrder(orderToUpdate!);

            _meters.IncreaseOrdersCanceled();

            return Unit.Value;
        }
    }
}
