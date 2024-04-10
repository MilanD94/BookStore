using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Data.Orders;
using MediatR;

namespace BookStore.Application.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersHandler(IOrderRepository orderRepository, IMapper mapper) : IRequestHandler<GetAllOrdersQuery, List<OrderRepresentation>>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<OrderRepresentation>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllOrders();

            var result = _mapper.Map<List<Models.Order>, List<OrderRepresentation>>(orders!);

            return result;
        }
    }
}