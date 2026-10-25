using ITEHAProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITEHAProject.Controllers;

public class AccessController : Controller
{
    private readonly SystemAdmin _systemAdmin = new SystemAdmin
    {
        Username = "admin",
        Password = "password",
    }; // creates a new system admin with username and password

    [HttpGet] // browser opens the page
    public IActionResult Login() // shows the login page
    {
        return View();
    }

    [HttpPost] // browser sends data to the server
    public IActionResult Login(string username, string password) // logs in the admin
    {
        if (username == _systemAdmin.Username && password == _systemAdmin.Password) // if username and password match the admin
        {
            HttpContext.Session.SetString("AdminUsername", username); // store the username in session
            return RedirectToAction("Index", "Staff"); // redirect to the staff index page
        }
        else // if username and password do not match the admin
        {
            return View(); // show the login page again
        }
    }

    public IActionResult Logout() // logs out the admin
    {
        HttpContext.Session.Remove("AdminUsername"); // remove the username from session
        return RedirectToAction("Login"); // redirect to the login page
    }
}
