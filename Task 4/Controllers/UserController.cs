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

        public IActionResult EditProfile()
        {
            return View();
        }

        public IActionResult saveData()
        {

            string address = Request.Form["Address"];
            string phone = Request.Form["Phone"];


            HttpContext.Session.SetString("Address", address);
            HttpContext.Session.SetString("Phone", phone);
            return RedirectToAction("Profile");
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
            string Remember = Request.Form["Remember"];

            string Stored_email = HttpContext.Session.GetString("Email");
            string Stored_password = HttpContext.Session.GetString("Password");

            if (Password == "123" && Email == "Admin@gmail.com")
            {
                HttpContext.Session.SetString("Email", Email);
                HttpContext.Session.SetString("Password", Password);
                return RedirectToAction("Index", "Home");
            }

            if (Email == Stored_email && Password == Stored_password) {

                if (Remember != null)
                {
                    CookieOptions obj = new CookieOptions();
                    obj.Expires = DateTime.Now.AddDays(7);
                    //store

                    Response.Cookies.Append("Email", Email, obj);
                    Response.Cookies.Append("Password", Password, obj);

                }

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

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("Email")== "Admin@gmail.com")
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            string username = HttpContext.Session.GetString("Username");
            CookieOptions obj = new CookieOptions();
            obj.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append("Username", username, obj);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
