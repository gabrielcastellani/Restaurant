using MediatR;
using Restaurant.Orders.Common.Models;

namespace Restaurant.Orders.Domain.Orders.Notifications
{
    internal record OrderCreatedNotification(Order Order) : INotification;
}
