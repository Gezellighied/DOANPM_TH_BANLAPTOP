using DOANPM_TH.Models;
using DOANPM_TH.Models.ClassModel;
using DOANPM_TH.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace DOANPM_TH.Controllers
{
    public class HomeCustomerController : Controller
    {
        DBHelper dbHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeCustomerController(DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            dbHelper = new DBHelper(context);
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Laptops> listlaptop = dbHelper.getLaptops();
            List<LatopsViewModel> latopsViewModels = new List<LatopsViewModel>();
            foreach (var laptop in listlaptop)
            {
                var latopsViewModel = new LatopsViewModel
                {
                    LaptopsID = laptop.LaptopID,
                    LaptopName = laptop.LaptopName,
                    Brand = laptop.Brand,
                    ScreenSize = laptop.ScreenSize,
                    Price = laptop.Price,
                    Processor = laptop.Processor,
                    Ram = laptop.Ram,
                    Image = laptop.Image,
                   
                };
                latopsViewModels.Add(latopsViewModel);
            }
            ViewData["listlaptop"] = latopsViewModels;
            return View();
        }
		
		public IActionResult laptopDetails(int? laptopId)
        {
            ViewBag.PageHeader = "Chi tiết sản phẩm";
            ViewBag.LaptopDetails = dbHelper.GetLaptopDetails(laptopId);
            return View();
        }
        //public IActionResult LaptopsDetails(int laptopID)
        //{
        //    Laptops laptops = dbHelper.GetLaptopDetails(laptopID);
        //    ViewBag.laptopDetails = laptops;
        //    return View();
        //}
    }
}
