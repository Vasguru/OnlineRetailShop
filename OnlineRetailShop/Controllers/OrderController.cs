using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineRetailShop.Api.Contracts;
using OnlineRetailShop.Api.Contracts.Interfaces;
using OnlineRetailShop.Api.Contracts.Model;
using System;
using System.Threading.Tasks;
using Entities = OnlineRetailShop.Api.Contracts.Entities;
namespace OnlineRetailShop.Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private IAutoMapConverter<CreateOrderRequest, Entities.Order> _mapModelToEntity;
        public OrderController(ILogger<OrderController> logger, IOrderService orderService,
             IAutoMapConverter<CreateOrderRequest, Entities.Order> mapModelToEntity)
        {
            _logger = logger;
            _orderService = orderService;
            _mapModelToEntity = mapModelToEntity;
        }

        [HttpPost("orderproduct")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> OrderProduct(CreateOrderRequest orderRequest)
        {
            try
            {
                var order = _mapModelToEntity.ConvertObject(orderRequest);
                var response = await _orderService.OrderProduct(order);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderProduct failed", ex.Message);

                var result = new ObjectResult(new
                {
                    code = 500,
                    message = "A server error occured.",
                    detailedMessage = ex.Message,
                    stackTrace = ex.StackTrace
                });

                result.StatusCode = 500;
                return result;
            }
        }

    }
}
