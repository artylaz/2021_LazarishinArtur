using Microsoft.AspNetCore.Mvc;

namespace _2021_LazarishinArtur.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
