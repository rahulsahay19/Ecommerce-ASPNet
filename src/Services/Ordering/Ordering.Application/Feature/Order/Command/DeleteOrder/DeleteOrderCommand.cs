using MediatR;

namespace Ordering.Application.Feature.Order.Command.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
