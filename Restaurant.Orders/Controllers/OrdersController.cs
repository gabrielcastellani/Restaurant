using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Orders.Application.Requests;
using Restaurant.Orders.Domain.Orders.Services;

namespace Restaurant.Orders.Controllers
{
    [ApiController]
    [Route("/api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var orders = _ordersService.GetAll();
                return Ok(orders);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateOrderRequest request)
        {
            try
            {
                var serverResponse = _ordersService.Add(
                    customerID: request.CustomerID,
                    products: request.Products);

                if (!serverResponse.Success)
                {
                    throw serverResponse.Error;
                }

                return Created(Request.GetDisplayUrl(), serverResponse.Model);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _ordersService.Delete(id);
                return NotFound();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
