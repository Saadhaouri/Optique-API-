using AutoMapper;
using Core.App.Dto.OrderDTO;
using Core.App.IServices;
using Microsoft.AspNetCore.Mvc;
using OptiqueAPI.ViewModels.Order;

namespace BetyParaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateUpdateOrderViewModel createOrderViewModel)
        {
            if (createOrderViewModel == null)
                return BadRequest();

            var createOrderDto = _mapper.Map<CreateUpdateOrderDto>(createOrderViewModel);
            var createdOrder = _orderService.CreateOrder(createOrderDto);

            var orderViewModel = _mapper.Map<OrderViewModel>(createdOrder);

            return Ok(orderViewModel);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderById(Guid orderId)
        {
            var order = _orderService.GetOrderById(orderId);

            if (order == null)
                return NotFound();

            var orderViewModel = _mapper.Map<OrderViewModel>(order);

            return Ok(orderViewModel);
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            var orderViewModels = _mapper.Map<List<OrderViewModel>>(orders);
            return Ok(orderViewModels);
        }

        [HttpPut("{orderId}")]
        public IActionResult UpdateOrder(Guid orderId, [FromBody] CreateUpdateOrderViewModel orderViewModel)
        {
            if (orderViewModel == null)
                return BadRequest();

            var orderDto = _mapper.Map<CreateUpdateOrderDto>(orderViewModel);
            _orderService.UpdateOrder(orderId, orderDto);

            return Ok("Order updated successfully");
        }

        [HttpDelete("{orderId}")]
        public IActionResult DeleteOrder(Guid orderId)
        {
            _orderService.DeleteOrder(orderId);
            return NoContent();
        }
    }
}
