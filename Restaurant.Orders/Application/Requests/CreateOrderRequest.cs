using System.ComponentModel.DataAnnotations;

namespace Restaurant.Orders.Application.Requests
{
    public record CreateOrderRequest(
        [Required] Guid CustomerID,
        [Required] object[] Products);
}
