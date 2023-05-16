using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Service;
using entities;


namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            this._orderService = orderService;
            _mapper = mapper;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            Order order = await _orderService.GetOrderById(id);
            OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order);
            return orderDTO != null ? Ok(orderDTO) : NoContent();
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orderDto)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDto);
            order = await _orderService.AddOrder(order);
            orderDto = _mapper.Map<Order, OrderDTO>(order);
            return orderDto.OrderId != 0 ? Ok(orderDto) : BadRequest();
        }
    }
}
