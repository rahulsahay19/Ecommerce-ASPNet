using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contract.Infrastructure;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Model;

namespace Ordering.Application.Feature.Order.Command.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IEmailService emailService,
            ILogger<CheckoutOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Domain.Entities.Order>(request);
            var generatedOrder = await _orderRepository.AddAsync(orderEntity);
            _logger.LogInformation($"Order {generatedOrder.Id} successfully created.");
            await SendMail(generatedOrder);
            return generatedOrder.Id;
        }

        //TODO: This needs to be implemented as a separate service.
        //This is just filler here
        private async Task SendMail(Domain.Entities.Order order)
        {
            var email = new Email() { To = "rahulsahay19@hotmail.com", Body = $"Order with id {order.Id} is created.", Subject = "Order created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Order {order.Id} failed due to an error: {ex.Message}");
            }
        }
    }
}
