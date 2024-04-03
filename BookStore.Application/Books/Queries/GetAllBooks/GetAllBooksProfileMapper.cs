using AutoMapper;

namespace BookStore.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksProfileMapper : Profile
    {
        public GetAllBooksProfileMapper()
        {
            CreateMap<Models.Book, DTOs.BookRepresentation>();
        }
    }
}
