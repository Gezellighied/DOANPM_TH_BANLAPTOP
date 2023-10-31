using DOANPM_TH.Models.ClassModel;
using Microsoft.AspNetCore.Http.Features;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DOANPM_TH.Models
{
    public class CartItemModel
    {
        //public int Id { get; set; }
        public int LaptopId { get; set; }
        public string LaptopName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public int Total
        {
            get { return Quantity * Price; }
        }
        public CartItemModel() { }
        public CartItemModel(Laptops laptop)
        {
            LaptopId = laptop.LaptopID;
            LaptopName = laptop.LaptopName;
            Quantity = 1;
            Image = laptop.Image;
            Price = laptop.Price;
        }
        
    }
}


