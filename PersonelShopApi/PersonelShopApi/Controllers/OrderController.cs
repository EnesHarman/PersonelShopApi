using Business.Abstract;
using Business.Constants;
using Business.Utilities.Abstract;
using Core.Entity.Concrete;
using Entity.Concrete;
using Entity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        IParser _jwtParser;
        
        public OrderController(IOrderService orderService,IParser parser)
        {
            _orderService = orderService;
            _jwtParser = parser;
        }

        [HttpPost("give")]
        [Authorize (Roles ="Member,Admin")]
        public IActionResult GiveOrder([FromBody]OrderDto orderDto)
        {
            
            var token = this.Request.Headers.GetCommaSeparatedValues("Authorization").First().Split(" ")[1];
            User user = _jwtParser.ParseJwtToUser(token);

            Order order = new Order
            {
                ProductId = orderDto.ProductId,
                UserID = user.Id,
            };
            var result =_orderService.Add(order);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("list")]
        [Authorize(Roles ="Member,Admin")]
        public IActionResult ListOrders()
        {
            var token = this.Request.Headers.GetCommaSeparatedValues("Authorization").First().Split(" ")[1];
            User user = _jwtParser.ParseJwtToUser(token);

            var result =_orderService.GetOrders(user.Id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("delete")]
        [Authorize(Roles ="Member,Admin")]
        public IActionResult DeleteOrder([FromBody] OrderDto orderDto)
        {
            var token = this.Request.Headers.GetCommaSeparatedValues("Authorization").First().Split(" ")[1];
            User user = _jwtParser.ParseJwtToUser(token);

            Order orderToDelete = new Order
            {
                UserID = user.Id,
                ProductId = orderDto.ProductId,
            };

            var result =_orderService.Delete(orderToDelete);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("execute")]
        [Authorize(Roles ="Member,Admin")]
        public async Task<IActionResult> ExecuteOrders()
        {

            var token = this.Request.Headers.GetCommaSeparatedValues("Authorization").First().Split(" ")[1];
            User user = _jwtParser.ParseJwtToUser(token);

            List<ProductDto> orders = _orderService.GetOrders(user.Id).Data;
            if(orders.Count == 0)
            {
                return BadRequest(Messages.OrderNotFound);
            }

            var result = await _orderService.Execute(user, orders);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
