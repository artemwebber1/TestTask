using Microsoft.EntityFrameworkCore;
using TestTask.DbContexts;
using TestTask.Models;

namespace TestTask.Services.Repositories.Orders
{
    public class OrdersRepository : IOrdersRepository
    {
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            using DatabaseContext dbContext = new DatabaseContext();
            IEnumerable<Order> orders = await dbContext.Orders.Include(o => o.Products).AsNoTracking().ToArrayAsync();
            return orders;
        }

        public async Task<Order> CreateOrderAsync(string orderName, params int[] productsId)
        {
            using DatabaseContext dbContext = new DatabaseContext();

            // Получение списка продуктов, id которых были указаны в параметре productsId
            ICollection<Product> products = await dbContext.Products.Where(p => productsId.Contains(p.ProductId)).ToListAsync();

            Order order = new Order
            {
                OrderName = orderName,
                Products = products
            };

            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();

            return order;
        }

        public async Task<Order> DeleteOrderAsync(int orderId)
        {
            using DatabaseContext dbContext = new DatabaseContext();

            // Получение заказа по id
            Order order = await dbContext.Orders
                .Include(o => o.Products)
                .FirstOrDefaultAsync(o => o.OrderId == orderId)
                ?? throw new NullReferenceException($"Order with id {orderId} doesn't exist.");

            // Сначала удаляются все продукты в заказе...
            order.Products.Clear();
            // ... а затем и сам заказ
            dbContext.Orders.Remove(order);

            await dbContext.SaveChangesAsync();

            return order;
        }
    }
}
