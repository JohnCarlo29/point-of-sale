using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Data;
using PointOfSale.DataTransferObjects;
using PointOfSale.Models;

namespace PointOfSale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public OrderController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Store(List<OrderItemData> orderItems)
        {
            var order = new Order
            {
                UserId = Int32.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!),
                TotalPrice = 100
            };
            // Create a new order record
            await _appDbContext.Orders.AddAsync(order);
            await _appDbContext.SaveChangesAsync();

            // Insert each order item associated with the order
            foreach (var item in orderItems)
            {
                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    AvailedPrice = item.Price,
                    TotalPrice = item.Price * item.Quantity,
                    OrderId = order.Id // Assuming OrderId is a foreign key in the OrderItem entity
                };
                await _appDbContext.OrderItems.AddAsync(orderItem);
            }

            await _appDbContext.SaveChangesAsync();

            return Ok("Order created successfully.");
        }
    }
}