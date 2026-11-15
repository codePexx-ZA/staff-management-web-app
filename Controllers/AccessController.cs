using ITEHAProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITEHAProject.Controllers;

public class AccessController : Controller
{
    private readonly SystemAdmin _systemAdmin = new SystemAdmin
    {
        Username = "admin",
        Password = "password",
    };

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (username == _systemAdmin.Username && password == _systemAdmin.Password)
        {
            HttpContext.Session.SetString("AdminUsername", username);
            return RedirectToAction("Index", "Staff");
        }
        else
        {
            return View();
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("AdminUsername");
        return RedirectToAction("Login");
    }
}
