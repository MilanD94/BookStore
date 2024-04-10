using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Data.Orders;
using MediatR;

namespace BookStore.Application.Orders.Queries.GetOrdersByBookId
{
    public class GetOrderByBookIdQueryHandler(IOrderRepository bookRepository, IMapper mapper) : IRequestHandler<GetOrderByBookIdQuery, List<OrderRepresentation>>
    {
        private readonly IOrderRepository _orderRepository = bookRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<OrderRepresentation>> Handle(GetOrderByBookIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByBookId(request.Id);

            var result = _mapper.Map<List<Models.Order>, List<OrderRepresentation>>(orders!);

            return result;
        }
    }
}