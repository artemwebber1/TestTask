using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestTask.Models
{
    public class Product
    {
        /// <summary>
        /// Id продукта.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Имя продукта.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;
    }
}
