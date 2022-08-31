using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using OnlineRetailShop.Api.Contracts;
using OnlineRetailShop.Api.Contracts.Interfaces;
using OnlineRetailShop.Api.Contracts.Model;
using OnlineRetailShop.Api.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRetailUnitTest
{

     public class OrderControllerTest
    {
        private readonly OrderController _controller;
        private readonly Mock<IOrderService> _service;
        private readonly Mock<ILogger<OrderController>> _logger;
        private readonly Mock<IAutoMapConverter<CreateOrderRequest, OnlineRetailShop.Api.Contracts.Entities.Order>> _autoMapConverter;

        public OrderControllerTest()
        {
            _service = new Mock<IOrderService>();
            _logger = new Mock<ILogger<OrderController>>();
            _autoMapConverter = new Mock<IAutoMapConverter<CreateOrderRequest, OnlineRetailShop.Api.Contracts.Entities.Order>>();
            _controller = new OrderController(_logger.Object, _service.Object, _autoMapConverter.Object);
        }

        [Fact]
        public async Task OrderProduct_ShouldReturnResponse()
        {
            var order = new CreateOrderRequest
            {
               Product_Id = 1,
               Quantity = 1
            };

            var result = (OkObjectResult)await _controller.OrderProduct(order);

            _service.Verify(_ => _.OrderProduct(_autoMapConverter.Object.ConvertObject(order)), Times.Exactly(1));
        }
    }
}
