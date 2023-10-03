using Microsoft.AspNetCore.Mvc;

namespace DOANPM_TH.Controllers
{
    public class HomeCustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
