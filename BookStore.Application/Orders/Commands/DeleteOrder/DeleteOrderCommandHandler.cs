using BookStore.Application.Metrics;
using BookStore.Data.Orders;
using MediatR;

namespace BookStore.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler(IOrderRepository orderRepository, BookStoreMetrics meters) : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly BookStoreMetrics _meters = meters;

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderById(request.Id) ?? throw new Exception("Order is not found.");

            await _orderRepository.DeleteOrder(order!);
            _meters.IncreaseOrdersCanceled();

            return Unit.Value;
        }
    }
}
