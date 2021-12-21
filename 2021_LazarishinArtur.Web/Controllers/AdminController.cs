using Microsoft.AspNetCore.Mvc;

namespace _2021_LazarishinArtur.Web.Controllers
{
    public class AdnminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
