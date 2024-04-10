using BookStore.Application.DTOs;
using MediatR;

namespace BookStore.Application.Orders.Queries.GetOrdersByBookId
{
    public class GetOrderByBookIdQuery : IRequest<List<OrderRepresentation>>
    {
        public Guid Id { get; set; }
    }
}
