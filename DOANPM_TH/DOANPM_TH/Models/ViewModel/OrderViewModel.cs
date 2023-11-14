using DOANPM_TH.Models.ClassModel;
using System.ComponentModel.DataAnnotations;

namespace DOANPM_TH.Models.ViewModel
{
	public class OrderViewModel
	{
		public int OrderID { get; set; }
		public int CustomerID { get; set; }
		public Customer Customer { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập tên người nhận.")]
		[StringLength(30, ErrorMessage = "Chiều dài vượt quá 30 ký tự.")]
		public string RecipientName { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
		[StringLength(30, ErrorMessage = "Chiều dài vượt quá 30 ký tự.")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập địa chỉ giao hàng.")]
		[StringLength(30, ErrorMessage = "Chiều dài vượt quá 30 ký tự.")]
		public string AddressDeliverry { get; set; }
		public int Total { get; set; }
		public string Status { get; set; }

		public Order ConvertOrder()
		{
			return new Order
			{
				CustomerID = CustomerID,
				RecipientName = RecipientName,
				Phone = Phone,
				AddressDeliverry = AddressDeliverry,
				Total = Total,
				Status = "Đang chờ xác nhận"
			};
		}
	}
}
