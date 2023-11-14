using System.ComponentModel.DataAnnotations;
namespace DOANPM_TH.Models.ClassModel
{
	public class Order
	{
		[Key]
		public int OrderID { get; set; }
		public int CustomerID { get; set; }
		public Customer Customer { get; set; }
		public string RecipientName { get; set; }
		public string Phone { get; set; }
		public string AddressDeliverry { get; set; }
		public int Total { get; set; }
		public string Status { get; set; }

	}
}
