using MediatR;

namespace BookStore.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? PublishDate { get; set; }
        public Guid? Id { get; set; }
    }
}
