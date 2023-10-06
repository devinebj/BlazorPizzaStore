using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDatabase.Entities {
    
    [Table("Customers")]
    public class Customer {
        public int CustomerId { get; set; }
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [DisplayName("Zip Code")]
        public string? PostalCode { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
