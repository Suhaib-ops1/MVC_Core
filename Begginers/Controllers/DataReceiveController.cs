using Microsoft.AspNetCore.Mvc;
using YourApp.Models;

namespace YourApp.Controllers
{
    public class DataReceiveController : Controller
    {
        // Method to handle Request.Form
        [HttpPost]
        public IActionResult RequestFormExample()
        {
            // Using Request.Form to retrieve form data
            string name = Request.Form["Name"];
            string age = Request.Form["Age"];

            return Content($"Name: {name}, Age: {age}");
        }

        // Method to handle FormCollection
        [HttpPost]
        public IActionResult FormCollectionExample(FormCollection collection)
        {
            // Using FormCollection to retrieve form data
            string name = collection["Name"];
            string age = collection["Age"];

            return Content($"Name: {name}, Age: {age}");
        }

        // Method to handle Model Binding
        [HttpPost]
        public IActionResult ModelBindingExample(UserModel user)
        {
            // Using Model Binding to automatically bind the form data to the model
            return Content($"Name: {user.Name}, Age: {user.Age}");
        }

        // Method to handle Query String
        public IActionResult QueryStringExample(string name, int age)
        {
            // Using query string parameters to pass data
            return Content($"Name: {name}, Age: {age}");
        }
    }
}
