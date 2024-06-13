using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTask.Services.Repositories.Orders;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public OrdersController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        private readonly IOrdersRepository _ordersRepository;

        #region Actions

        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _ordersRepository.GetAllOrdersAsync();
        }

        [HttpPost("CreateOrder")]
        public async Task<IResult> CreateOrderAsync(string orderName, params int[] productsId)
        {
            Order createdOrder = await _ordersRepository.CreateOrderAsync(orderName, productsId);
            return Results.Ok($"Created order with id {createdOrder.OrderId}.");
        }

        [HttpDelete("DeleteOrder")]
        public async Task<IResult> DeleteOrderAsync(int orderId)
        {
            await _ordersRepository.DeleteOrderAsync(orderId);
            return Results.Ok($"Deleted order with id {orderId}.");
        }

        #endregion
    }
}
