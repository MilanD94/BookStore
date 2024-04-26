using AutoMapper;

namespace BookStore.Application.Orders.Queries.Common
{
    public class GetAllOrdersProfileMapper : Profile
    {
        public GetAllOrdersProfileMapper()
        {
            CreateMap<Models.Order, DTOs.OrderRepresentation>()
                .ForMember(dest => dest.Address, act => act.MapFrom(src => src.Address))
                .ForMember(dest => dest.CustomerName, act => act.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.Telephone, act => act.MapFrom(src => src.Telephone))
                .ForMember(dest => dest.City, act => act.MapFrom(src => src.City))
                .ForMember(dest => dest.Status, act => act.MapFrom(src => src.Status))
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.TotalAmount, act => act.MapFrom(src => src.TotalAmount))
                .ForPath(dest => dest.Books, act => act.MapFrom(src => src.Books));

            CreateMap<Models.Book, DTOs.BookRepresentation>()
               .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
               .ForMember(dest => dest.Value, act => act.MapFrom(src => src.Value))
               .ForMember(dest => dest.Author, act => act.MapFrom(src => src.Author))
               .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description))
               .ForMember(dest => dest.PublishDate, act => act.MapFrom(src => src.PublishDate))
               .ForPath(dest => dest.CategoryName, act => act.MapFrom(src => src.Category!.Name))
               .ForPath(dest => dest.CategoryId, act => act.MapFrom(src => src.Category!.Id));
        }
    }
}
