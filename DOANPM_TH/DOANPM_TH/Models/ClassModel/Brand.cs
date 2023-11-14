using System.ComponentModel.DataAnnotations;
namespace DOANPM_TH.Models.ClassModel
{
	public class Brand
	{
		[Key]
		public int BrandID { get; set; }
		public string Name { get; set; }
	}
}
