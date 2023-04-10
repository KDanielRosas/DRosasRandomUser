using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class RandomUserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
