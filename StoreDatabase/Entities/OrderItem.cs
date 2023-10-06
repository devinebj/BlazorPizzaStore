using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDatabase.Entities {

    [Table("OrderItems")]
    public class OrderItem {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public virtual Product? Product { get; set; } = null;
    }
}
