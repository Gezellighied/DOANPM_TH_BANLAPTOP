using System.ComponentModel.DataAnnotations;
namespace DOANPM_TH.Models.ClassModel
{
	public class Laptops
    {
        [Key]
        public int LaptopID { get; set; }
        public string LaptopName { get; set; }
        public string Brand { get; set; }
        public string ScreenSize { get; set; }
        public string Processor { get; set; }
        public string Ram { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
