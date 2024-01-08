using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminStatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
