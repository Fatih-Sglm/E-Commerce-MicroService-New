using E_Commerce.OrderService.Application.Features.Orders.Command.PaymentOrder;
using E_Commerce.OrderService.Application.Features.Orders.Queries.GetAllOrdersList;
using E_Commerce.OrderService.Application.Features.Orders.Queries.GetOrderById;
using E_Commerce.OrderService.Application.Features.Orders.Queries.GetUserOrdersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.OrderService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{OrderId}")]
        public async Task<IActionResult> GetOrderDetail([FromRoute] GetOrderByIdQuery getOrderByIdQuery)
        {
            return Ok(await _mediator.Send(getOrderByIdQuery));
        }

        [HttpGet("GetUserOrders")]
        public async Task<IActionResult> GetUserOrders([FromQuery] GetUserOrdersListQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> PayOrder(PaymentOrderCommand paymentOrder)
        {
            return Ok(await _mediator.Send(paymentOrder));
        }
    }
}
