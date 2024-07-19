using MediatR;
using Restaurant.Orders.Common.Models;
using Restaurant.Orders.Common.Responses;
using Restaurant.Orders.Domain.Orders.Commands;
using Restaurant.Orders.Domain.Orders.Notifications;
using Restaurant.Orders.Infrastructure.Repositories.Interfaces;

namespace Restaurant.Orders.Domain.Orders.Services
{
    internal class OrdersService : IOrdersService
    {
        private readonly IMediator _mediator;
        private readonly ILogger<IOrdersService> _logger;
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(
            IMediator mediator,
            ILoggerFactory loggerFactory,
            IOrdersRepository ordersRepository)
        {
            _mediator = mediator;
            _ordersRepository = ordersRepository;
            _logger = loggerFactory.CreateLogger<IOrdersService>();
        }

        public Order[] GetAll()
        {
            return _ordersRepository.GetAll();
        }

        public ServerResponse<Order> Add(Guid customerID, object[] products)
        {
            var command = new CreateOrderCommand(customerID, products);
            var response = _mediator.Send(command).GetAwaiter().GetResult();

            if (!response.Success)
            {
                _logger.LogError(response.Error, response.Error.Message);
                return response;
            }

            var notification = new OrderCreatedNotification(response.Model);
            _mediator.Publish(notification);

            return response;
        }

        public void Delete(Guid orderID)
        {
            _ordersRepository.Delete(orderID);
        }
    }
}
