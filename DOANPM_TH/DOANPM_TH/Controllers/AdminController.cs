using DOANPM_TH.Models.ClassModel;
using DOANPM_TH.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace DOANPM_TH.Controllers
{
    public class AdminController : Controller
    {
        DBHelper dbHelper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminController(DatabaseContext context, IWebHostEnvironment hostEnvironment)
        {
            dbHelper = new DBHelper(context);
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index(string searchSLaptop)
        {
			ViewData["PageTitle"] = "listlaptop";
			if (searchSLaptop != null && searchSLaptop.Length > 0)
				ViewBag.listlaptop = dbHelper.SearchLaptop(searchSLaptop);
			else
				ViewBag.listlaptop = dbHelper.getLaptops();
			return View();
		}
		public IActionResult Create()
		{
			ViewData["PageTitle"] = "Createlaptop";
			return View();
		}
		[HttpPost]
		public IActionResult Create(LatopsViewModel newLaptops)
		{
			IFormFile imageFile = newLaptops.ImageFile;
			ModelState.Remove("Image");
			ModelState.Remove("ImageFile");
			if (ModelState.IsValid)
			{
				if (imageFile != null && imageFile.Length > 0)
				{
					// Đảm bảo đường dẫn thư mục image
					var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Content/HinhAnhSP");

					// Tạo tên tệp ảnh duy nhất bằng cách sử dụng Guid và đuôi tệp ảnh ban đầu
					var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

					// Kết hợp đường dẫn đến thư mục image và tên tệp ảnh để có đường dẫn đầy đủ
					var filePath = Path.Combine(imagePath, fileName);

					// Lưu tệp ảnh vào thư mục image
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						imageFile.CopyTo(stream);
					}

					// Lưu đường dẫn tệp ảnh vào thuộc tính Image của sản phẩm
					newLaptops.Image = fileName;
				}

				Laptops newLaptop = new Laptops
				{
					LaptopID=newLaptops.LaptopsID,
					LaptopName=newLaptops.LaptopName,
					Brand=newLaptops.Brand,
					ScreenSize=newLaptops.ScreenSize,
					Processor=newLaptops.Processor,
					Ram=newLaptops.Ram,
					Price = newLaptops.Price,
					Image = newLaptops.Image
				};

				dbHelper.InsertLaptop(newLaptop);
				return RedirectToAction("laptopDetails", new { laptopID = dbHelper.GetNewLaptop().LaptopID });
			}

			// Nếu ModelState không hợp lệ, cần lấy lại danh sách productTypes và providers để hiển thị lại trên form.
			return View(newLaptops);
		}
		public IActionResult laptopDetails(int? laptopId)
		{
			ViewBag.PageHeader = "Chi tiết sản phẩm";
			ViewBag.laptopDetails = dbHelper.GetLaptopDetails(laptopId);
			return View();
		}
		public IActionResult Delete(int laptopId)
		{
			ViewBag.productDelete = dbHelper.GetLaptopsById(laptopId);
			return View();
		}
		public IActionResult DeleteById(int laptopId)
		{
			dbHelper.DeleteLaptop(laptopId);
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int laptopId)
		{
			ViewData["PageTitle"] = "Edit Product";

			Laptops laptop = dbHelper.GetLaptopsById(laptopId);
			LatopsViewModel laptopVM = new LatopsViewModel()
			{
				LaptopsID = laptop.LaptopID,
				LaptopName = laptop.LaptopName,
				Brand = laptop.Brand,
				ScreenSize = laptop.ScreenSize,
				Processor = laptop.Processor,
				Ram = laptop.Ram,
				Price = laptop.Price,
				Image =  laptop.Image
				
			};

			if (laptopVM == null)
				return NotFound();

			//ViewBag.productTypes = dBHelper.GetProductTypes();
			//ViewBag.providers = dBHelper.GetProviders();

			return View(laptopVM);
		}

		[HttpPost]
		public IActionResult Edit(LatopsViewModel laptopVM, IFormFile imageFile)
		{
			{
				if (imageFile != null && imageFile.Length > 0)
				{
					// Đảm bảo đường dẫn thư mục image
					var imagePath = Path.Combine(_hostEnvironment.WebRootPath,"Content/HinhAnhSP");

					// Tạo tên tệp ảnh duy nhất bằng cách sử dụng Guid và đuôi tệp ảnh ban đầu
					var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

					// Kết hợp đường dẫn đến thư mục image và tên tệp ảnh để có đường dẫn đầy đủ
					var filePath = Path.Combine(imagePath, fileName);

					// Lưu tệp ảnh vào thư mục image
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						imageFile.CopyTo(stream);
					}

					// Lưu đường dẫn tệp ảnh vào thuộc tính Image của sản phẩm
					laptopVM.Image = fileName;
				}

				Laptops newLaptop = new Laptops()
				{
					LaptopID = laptopVM.LaptopsID,
					LaptopName = laptopVM.LaptopName,
					Brand = laptopVM.Brand,
					ScreenSize = laptopVM.ScreenSize,
					Processor = laptopVM.Processor,
					Ram = laptopVM.Ram,
					Price = laptopVM.Price,
					Image = laptopVM.Image
				};
				dbHelper.UpdateLaptop(newLaptop);
				return RedirectToAction("Index");
			}
			return View(laptopVM);
		}
	}
}
