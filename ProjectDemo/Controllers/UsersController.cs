using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectDemo.DAL;
using System;
using System.Security.Claims;

namespace ProjectDemo.Controllers
{
    public class UsersController : Controller
    {
        private readonly IConfiguration configuration;
        UsersDAL usersdal;
        public UsersController(IConfiguration configuration)
        {
            this.configuration = configuration;
            usersdal = new UsersDAL(configuration);
        }
        // GET: UsersController
        public IActionResult Register()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        public IActionResult Register(Users users)
        {
            try
            {
                int res = usersdal.UsersRegister(users);
                if (res == 1)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Login(Users users)
        {
            Users user = usersdal.UsersLogin(users);
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, users.Name) },
                CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            HttpContext.Session.SetInt32("user_id", users.user_id);
            HttpContext.Session.SetString("email", users.Email);
            HttpContext.Session.SetInt32("Contact_no", users.Contact_no);
            HttpContext.Session.SetInt32("role_id", users.role_id);

            if (user != null)
            {
                if (user.role_id == 1)
                {
                    return RedirectToAction("Create", "Product");
                }
                else if (user.role_id == 2)
                {
                    return RedirectToAction("List", "Product");
                }
                return View();
            }
            return View();
        }
        // POST: UsersController/Delete/5
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            var StoredCookies = Request.Cookies.Keys;
            foreach(var Cookie in StoredCookies)
            {
                Response.Cookies.Delete(Cookie);
            }
            return RedirectToAction("Login");
        }

    }

 
        
}
    

