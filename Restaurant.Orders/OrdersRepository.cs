using Restaurant.Orders.Common.Models;
using Restaurant.Orders.Infrastructure.Repositories;
using Restaurant.Orders.Infrastructure.Repositories.Interfaces;

namespace Restaurant.Orders
{
    internal class OrdersRepository : Repository<Order>, IOrdersRepository
    { }
}
