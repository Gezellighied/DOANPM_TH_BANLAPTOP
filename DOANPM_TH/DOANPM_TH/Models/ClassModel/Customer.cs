using System.ComponentModel.DataAnnotations;

namespace DOANPM_TH.Models.ClassModel
{
	public class Customer
	{
		[Key]
		public int CustomerId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}