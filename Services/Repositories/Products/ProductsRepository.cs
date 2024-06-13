using Microsoft.EntityFrameworkCore;
using TestTask.DbContexts;
using TestTask.Models;

namespace TestTask.Services.Repositories.Products
{
    public class ProductsRepository : IProductsRepository
    {   
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            using DatabaseContext dbContext = new DatabaseContext();
            IEnumerable<Product> products = await dbContext.Products.AsNoTracking().ToArrayAsync();
            return products;
        }

        public async Task AddProductToOrderAsync(int productId, int orderId)
        {
            using DatabaseContext dbContext = new DatabaseContext();

            Order? order = dbContext.Orders
                .Include(o => o.Products)
                .FirstOrDefault(o => o.OrderId == orderId) 
                ?? throw new NullReferenceException($"Order with id {orderId} doesn't exist.");

            Product? product = await dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId)
                ?? throw new NullReferenceException($"Product with id {productId} doesn't exist.");

            order.Products.Add(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Product> CreateProductAsync(string productName)
        {
            using DatabaseContext dbContext = new DatabaseContext();

            Product product = new Product
            {
                ProductName = productName,
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProductAsync(int productId)
        {
            using DatabaseContext dbContext = new DatabaseContext();
            await dbContext.Products.Where(p => p.ProductId == productId).ExecuteDeleteAsync();
        }
    }
}
