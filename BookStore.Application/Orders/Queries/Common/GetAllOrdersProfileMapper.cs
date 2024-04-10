using AutoMapper;

namespace BookStore.Application.Orders.Queries.Common
{
    public class GetAllOrdersProfileMapper : Profile
    {
        public GetAllOrdersProfileMapper()
        {
            CreateMap<Models.Order, DTOs.OrderRepresentation>();
        }
    }
}
