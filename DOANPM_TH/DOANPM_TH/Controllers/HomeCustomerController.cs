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
        //[HttpPost]
        //public IActionResult Search(string searchSLaptop)
        //{
        //    ViewData["PageTitle"] = "listlaptop";
        //    if (searchSLaptop != null && searchSLaptop.Length > 0)
        //        ViewData["listlaptop"] = dbHelper.SearchLaptop(searchSLaptop);
        //    else
        //        ViewData["listlaptop"] = dbHelper.getLaptops();
        //    return RedirectToAction("Index");
        //}
        public IActionResult Index(string searchSLaptop)
        {
            ViewData["PageTitle"] = "listlaptop";
            if (searchSLaptop != null && searchSLaptop.Length > 0)
                ViewBag.listlaptop = dbHelper.SearchLaptop(searchSLaptop);
            else
                ViewBag.listlaptop = dbHelper.getLaptops();
            return View();
        }
		
		public IActionResult laptopDetails(int? laptopId)
        {
            ViewBag.PageHeader = "Chi tiết sản phẩm";
            ViewBag.LaptopDetails = dbHelper.GetLaptopDetails(laptopId);
            return View();
        }
    }
}
