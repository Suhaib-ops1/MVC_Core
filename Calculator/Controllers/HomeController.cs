using System.Diagnostics;
using Calculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult HandleIndex(int number1, int number2, string operation)
        {
          
            double result = 0;
            string message = "";

            switch (operation)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    if (number2 != 0)
                        result = (double)number1 / number2;
                    else
                        message = "Cannot divide by zero!";
                    break;
                default:
                    message = "Invalid operation!";
                    break;
            }

            TempData["Result"] = message == "" ? $"Result: {result}" : $"Warning :{message}" ;
            return RedirectToAction("Index");
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
