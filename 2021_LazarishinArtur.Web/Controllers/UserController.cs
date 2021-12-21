using Microsoft.AspNetCore.Mvc;

namespace _2021_LazarishinArtur.Web.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Calculations()
        {
            return View();
        }
    }
}
