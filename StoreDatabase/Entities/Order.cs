using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDatabase.Entities {

    [Table("Orders")]
    public class Order {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set;}
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
