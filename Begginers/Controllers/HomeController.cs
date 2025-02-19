using System.Diagnostics;
using Begginers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Begginers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
     

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

public class HomeController : Controller
{
    [HttpGet] // Shows the form
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost] // Handles form submission
    public IActionResult Index(string name)
    {
        ViewBag.Message = "Hello, " + name;
        return View();
    }



    // 2?? RedirectToAction() ? Redirects to another action in the same controller
    public IActionResult GoToAbout()
    {
        return RedirectToAction("About");
    }

    public IActionResult About()
    {
        return View();
    }

    // 3?? Redirect() ? Redirects to an external website
    public IActionResult GoToGoogle()
    {
        return Redirect("https://www.google.com");
    }
}

