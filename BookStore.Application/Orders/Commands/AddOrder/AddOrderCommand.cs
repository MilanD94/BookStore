using BookStore.Application.DTOs;
using MediatR;

namespace BookStore.Application.Orders.Commands.AddOrder
{
    public class AddOrderCommand : IRequest<OrderRepresentation>
    {
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? City { get; set; }
        public string? TotalAmount { get; set; }
        public string? Status { get; set; }
    }
}
