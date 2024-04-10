using AutoMapper;
using BookStore.API.Requests.Books;
using BookStore.Application.Books.Commands.AddBook;
using BookStore.Application.Books.Commands.UpdateBook;

namespace BookStore.API.Common.Mappers
{
    public class BooksProfileMapper : Profile
    {
        public BooksProfileMapper()
        {
            CreateMap<AddBookRequest, AddBookCommand>();

            CreateMap<UpdateBookRequest, UpdateBookCommand>();
        }
    }
}
