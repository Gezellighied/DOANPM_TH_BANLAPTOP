using System.ComponentModel.DataAnnotations;
namespace DOANPM_TH.Models.ClassModel
{
	public class Carts
	{
		[Key]
		public int CartID { get; set; }
		public int CustomerID { get; set; }
		public Customer Customer { get; set; }

		public int LaptopID { get; set; }
		public Laptops Laptops { get; set; }

		public int Quantity { get; set; }
	}
}
