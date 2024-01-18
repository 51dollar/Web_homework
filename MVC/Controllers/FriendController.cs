using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class FriendController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
