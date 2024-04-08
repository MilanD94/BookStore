using BookStore.Application.DTOs;
using MediatR;

namespace BookStore.Application.Books.Commands
{
    public class AddBookCommand : IRequest<BookRepresentation>
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? PublishDate { get; set; }
    }
}
