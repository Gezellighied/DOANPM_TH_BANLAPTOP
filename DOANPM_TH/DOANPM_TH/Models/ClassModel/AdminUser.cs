using System.ComponentModel.DataAnnotations;
namespace DOANPM_TH.Models.ClassModel
{
	public class AdminUser
	{
		[Key]
		public int AdminUserID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int? Role { get; set; }
	}
}
