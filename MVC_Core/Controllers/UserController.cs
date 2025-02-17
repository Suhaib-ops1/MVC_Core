using Microsoft.AspNetCore.Mvc;

namespace MVC_Core.Controllers
{
    public class UserController : Controller
    {
        public IActionResult RoomsList()
        {
            return View();
        }
    }
}
