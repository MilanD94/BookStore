using AutoMapper;

namespace BookStore.Application.Books.Commands.Common
{
    public class BookProfileMapper : Profile
    {
        public BookProfileMapper()
        {
            CreateMap<Models.Book, DTOs.BookRepresentation>();
        }
    }
}
