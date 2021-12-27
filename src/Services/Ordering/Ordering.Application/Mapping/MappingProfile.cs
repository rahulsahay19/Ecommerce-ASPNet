using AutoMapper;
using Ordering.Application.Feature.Order.Command.CheckoutOrder;
using Ordering.Application.Feature.Order.Command.UpdateOrder;
using Ordering.Application.Feature.Order.Query.GetOrdersList;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mapping
{
   public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
