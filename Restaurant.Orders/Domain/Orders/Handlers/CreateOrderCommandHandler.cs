using MediatR;
using Restaurant.Orders.Common.Models;
using Restaurant.Orders.Common.Responses;
using Restaurant.Orders.Domain.Orders.Commands;
using Restaurant.Orders.Infrastructure.Repositories.Interfaces;

namespace Restaurant.Orders.Domain.Orders.Handlers
{
    internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ServerResponse<Order>>
    {
        private readonly IOrdersRepository _ordersRepository;

        public CreateOrderCommandHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public Task<ServerResponse<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            ServerResponse<Order> response;

            try
            {
                Order order = new()
                {
                    ID = Guid.NewGuid(),
                    CustomerID = request.CustomerID,
                    Products = request.Products,
                };

                _ordersRepository.Add(order);

                response = new ServerResponse<Order>(order);
            }
            catch (Exception error)
            {
                var exception = new Exception("Failure on create a new order.", error);
                response = new ServerResponse<Order>(exception);
            }

            return Task.FromResult(response);
        }
    }
}
