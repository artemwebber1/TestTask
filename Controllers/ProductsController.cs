using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTask.Services.Repositories.Products;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        private readonly IProductsRepository _productsRepository;

        #region Actions

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productsRepository.GetAllProductsAsync();
        }

        [HttpPut("AddProductToOrder")]
        public async Task<IResult> AddProductToOrderAsync(int productId, int orderId)
        {
            await _productsRepository.AddProductToOrderAsync(productId, orderId);
            return Results.Ok($"Added product with id {productId} to order with id {orderId}.");
        }

        [HttpPost("CreateProduct")]
        public async Task<IResult> CreateProductAsync(string productName)
        {
            await _productsRepository.CreateProductAsync(productName);
            return Results.Ok($"Created product {productName}.");
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IResult> DeleteProductAsync(int productId)
        {
            await _productsRepository.DeleteProductAsync(productId);
            return Results.Ok($"Deleted product with id {productId}.");
        }

        #endregion
    }
}
