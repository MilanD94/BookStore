using BookStore.Application.DTOs;
using MediatR;

namespace BookStore.Application.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<List<OrderRepresentation>>
    {
    }
}
