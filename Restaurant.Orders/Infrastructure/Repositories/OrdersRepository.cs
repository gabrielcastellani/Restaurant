using Restaurant.Orders.Common.Models;
using Restaurant.Orders.Infrastructure.Repositories.Interfaces;

namespace Restaurant.Orders.Infrastructure.Repositories
{
    internal class OrdersRepository : Repository<Order>, IOrdersRepository
    { }
}
