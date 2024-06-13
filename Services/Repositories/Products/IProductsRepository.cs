using TestTask.Models;

namespace TestTask.Services.Repositories.Products
{
    public interface IProductsRepository
    {
        /// <summary>
        /// Получение всех товаров из соответствующей таблицы в базе данных.
        /// </summary>
        /// <returns>Список объектов <see cref="Product"/>, соответствующих записям в таблице.</returns>
        Task<IEnumerable<Product>> GetAllProductsAsync();

        /// <summary>
        /// Добавление товара в заказ.
        /// </summary>
        /// <param name="productId">Id товара, который будет добавлен в заказ.</param>
        /// <param name="orderId">Id заказа, в который будет добавлен продукт.</param>
        /// <returns>Объект <see cref="Task"/>, представляющий асинхронную операцию.</returns>
        Task AddProductToOrderAsync(int productId, int orderId);

        /// <summary>
        /// Создание нового товара.
        /// </summary>
        /// <param name="productName">Имя нового продукта.</param>
        /// <returns>Объект класса <see cref="Product"/>, соответствующий созданному товару.</returns>
        Task<Product> CreateProductAsync(string productName);

        /// <summary>
        /// Удаление конкретного товара из базы данных.
        /// </summary>
        /// <param name="productId">Id товара, который нужно удалить.</param>
        /// <returns>Объект <see cref="Task"/>, представляющий асинхронную операцию.</returns>
        Task DeleteProductAsync(int productId);
    }
}
