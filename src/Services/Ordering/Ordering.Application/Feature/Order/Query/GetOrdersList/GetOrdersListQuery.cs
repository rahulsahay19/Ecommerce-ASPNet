using System.Collections.Generic;
using MediatR;

namespace Ordering.Application.Feature.Order.Query.GetOrdersList
{
   public class GetOrdersListQuery:IRequest<List<OrderDto>>
    {
        public string UserName { get; set; }

        public GetOrdersListQuery(string userName)
        {
            UserName = userName;
        }
    }
}
