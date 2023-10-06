using System.ComponentModel;

namespace PizzaStoreModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [DisplayName("Customer Name")]
        public string FullName => $"{LastName}, {FirstName}";
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [DisplayName("Zip Code")]
        public string? PostalCode { get; set; }
    }
}
