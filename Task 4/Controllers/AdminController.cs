using Microsoft.AspNetCore.Mvc;

namespace MVC_Core.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult UsersList()
        {
            return View();
        }
    }
}
