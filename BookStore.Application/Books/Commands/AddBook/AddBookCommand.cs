using MediatR;

namespace BookStore.Application.Books.Commands.AddBook
{
    public class AddBookCommand : IRequest<Unit>
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public DateTime? PublishDate { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
