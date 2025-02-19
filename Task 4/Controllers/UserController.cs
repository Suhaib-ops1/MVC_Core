using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Task_4.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult HandleRegister()
        {
            string Name= Request.Form["name"];  
            string Email= Request.Form["email"];    
             string Password= Request.Form["password"];
            string RepeatPassword = Request.Form["repeatpassword"];
            if (Password == RepeatPassword)
            {

                HttpContext.Session.SetString("Username", Name);
                HttpContext.Session.SetString("Email", Email);
                HttpContext.Session.SetString("Password", Password);

                return RedirectToAction("Login");

            }
            else
            {

                return RedirectToAction("Register");
            }
        }
        public IActionResult HandleLogin()
        {   
            string Email=Request.Form["Email"];
            string Password= Request.Form["Password"];

            string Stored_email = HttpContext.Session.GetString("Email");
            string Stored_password = HttpContext.Session.GetString("Password");
            if (Email == Stored_email && Password == Stored_password) {

                return RedirectToAction("Index" , "Home");
            }

            return View();
        }
        public IActionResult Profile()
        {
           ViewData["Uname"]= HttpContext.Session.GetString("Username");
            ViewData["Uemail"] = HttpContext.Session.GetString("Email");
            ViewData["Upassword"] = HttpContext.Session.GetString("Password");
            
            return View();
        }
    }
}
