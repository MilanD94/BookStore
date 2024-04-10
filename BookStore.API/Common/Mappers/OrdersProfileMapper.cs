using AutoMapper;
using BookStore.API.Requests.Orders;
using BookStore.Application.Orders.Commands.AddOrder;
using BookStore.Application.Orders.Commands.UpdateOrder;

namespace BookStore.API.Common.Mappers
{
    public class OrdersProfileMapper : Profile
    {
        public OrdersProfileMapper()
        {
            CreateMap<AddOrderRequest, AddOrderCommand>();

            CreateMap<UpdateOrderRequest, UpdateOrderCommand>();
        }
    }
}