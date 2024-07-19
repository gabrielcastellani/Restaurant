using MediatR;
using Restaurant.Orders.Common.Models;
using Restaurant.Orders.Common.Responses;

namespace Restaurant.Orders.Domain.Orders.Commands
{
    internal record CreateOrderCommand(Guid CustomerID, object[] Products) : IRequest<ServerResponse<Order>>;
}