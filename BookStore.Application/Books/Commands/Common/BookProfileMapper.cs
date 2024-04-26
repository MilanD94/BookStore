using AutoMapper;

namespace BookStore.Application.Books.Commands.Common
{
    public class BookProfileMapper : Profile
    {
        public BookProfileMapper()
        {
            CreateMap<Models.Book, DTOs.BookRepresentation>()
                .ForPath(dest => dest.CategoryName, act => act.MapFrom(src => src.Category!.Name))
                .ForPath(dest => dest.CategoryId, act => act.MapFrom(src => src.Category!.Id));
        }
    }
}
