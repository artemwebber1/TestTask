namespace TestTask.Models
{
    public class Order
    {
        /// <summary>
        /// Id заказа.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Название заказа.
        /// </summary>
        public string OrderName { get; set; } = string.Empty;

        /// <summary>
        /// Продукты в заказе.
        /// </summary>
        public ICollection<Product> Products { get; set; } = [];
    }
}
