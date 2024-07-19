using Restaurant.Orders.Common.Models;
using Restaurant.Orders.Common.Responses;

namespace Restaurant.Orders.Domain.Orders.Services
{
    public interface IOrdersService
    {
        Order[] GetAll();
        ServerResponse<Order> Add(Guid customerID, object[] products);
        void Delete(Guid orderID);
    }
}
