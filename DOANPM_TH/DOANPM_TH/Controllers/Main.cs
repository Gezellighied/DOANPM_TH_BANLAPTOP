using Microsoft.AspNetCore.Mvc;

namespace DOANPM_TH.Controllers
{
    public class Main : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
