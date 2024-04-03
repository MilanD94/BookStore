using BookStore.Application.DTOs;
using MediatR;

namespace BookStore.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BookRepresentation>>
    {
    }
}
