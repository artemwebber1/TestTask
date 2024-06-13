using TestTask.Models;

namespace TestTask.Services.Repositories.Orders
{
    public interface IOrdersRepository
    {
        /// <summary>
        /// Получение всех заказов из соответствующей таблицы в базе данных.
        /// </summary>
        /// <returns>Список объектов <see cref="Order"/>, соответствующих записям в таблице.</returns>
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        /// <summary>
        /// Создание нового заказа.
        /// </summary>
        /// <param name="orderName">Имя нового заказа.</param>
        /// <param name="productsId">Список id продуктов, которые будут добавлены в заказ при его создании.</param>
        /// <returns>Объект класса <see cref="Order"/>, соответствующий созданному заказу..</returns>
        Task<Order> CreateOrderAsync(string orderName, params int[] productsId);

        /// <summary>
        /// Удаление конкретного заказа из базы данных.
        /// </summary>
        /// <param name="orderId">Id заказа, который нужно удалить.</param>
        /// <returns>Объект класса <see cref="Order"/>, соответствующий удалённому заказу.</returns>
        Task<Order> DeleteOrderAsync(int orderId);
    }
}
