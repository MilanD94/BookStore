using MediatR;

namespace BookStore.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Unit>
    {
        public Guid? Id { get; set; }
    }
}
