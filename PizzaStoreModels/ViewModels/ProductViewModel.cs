using System.ComponentModel;

namespace PizzaStoreModels.ViewModels {
	public class ProductViewModel {
		public int ProductId { get; set; }
		[DisplayName("Product Name")]
		public string? Name { get; set; }
		[DisplayName("Product Price")]
		public float? Price { get; set; }
	}
}