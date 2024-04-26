using AutoMapper;
using BookStore.API.Requests.Orders;
using BookStore.Application.Orders.Commands.AddOrder;

namespace BookStore.API.Common.Mappers
{
    public class OrdersProfileMapper : Profile
    {
        public OrdersProfileMapper()
        {
            CreateMap<AddOrderRequest, AddOrderCommand>();
        }
    }
}