using System.ComponentModel.DataAnnotations;
namespace DOANPM_TH.Models.ClassModel
{
	public class OrderDetails
	{
		[Key]
		public int OrderID { get; set; }
		public Order Order { get; set; }
		[Key]
		public int LaptopID { get; set; }
		public Laptops Laptops	 { get; set; }
		public int Price { get; set; }
		public int Quantity { get; set; }
		public int Total { get; set; }
	}
}
