using Microsoft.AspNetCore.Mvc;

namespace Begginers.Controllers
{
    public class DataController : Controller
    {
        // Action to demonstrate ViewData
        public IActionResult ViewDataExample()
        {
            // Passing data via ViewData (using an array)
            ViewData["Message"] = "Hello from ViewData!";
            ViewData["Numbers"] = new int[] { 1, 2, 3, 4, 5 };

            return View();
        }

        // Action to demonstrate ViewBag
        public IActionResult ViewBagExample()
        {
            // Passing data via ViewBag (using a List)
            ViewBag.Message = "Hello from ViewBag!";
            ViewBag.Numbers = new List<int> { 6, 7, 8, 9, 10 };
            ViewBag.Hala = "I am not in the bag";

            return View();
        }

        // Action to demonstrate TempData
        public IActionResult TempDataExample()
        {
            // Passing data via TempData (data persists across redirects)
            TempData["Message"] = "Hello from TempData!";

            return RedirectToAction("TempDataDisplay");
        }

        public IActionResult TempDataDisplay()
        {
            // Displaying TempData on a separate page
            return View();
        }
    }
}
