using Microsoft.AspNetCore.Mvc;

namespace DOANPM_TH.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
