using System.ComponentModel.DataAnnotations;
namespace DOANPM_TH.Models.ClassModel
{
	public class Cart
	{
		[Key]
		public int CartID { get; set; }
		public int CustomerID { get; set; }
		public Customer Customer { get; set; }

		public int LaptopID { get; set; }
		public Laptops Laptop { get; set; }

		public int Quantity { get; set; }
	}
}
