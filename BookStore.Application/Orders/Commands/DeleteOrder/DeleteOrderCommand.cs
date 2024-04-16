using MediatR;

namespace BookStore.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public Guid? Id { get; set; }
    }
}
