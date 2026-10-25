using ITEHAProject.Models;
using ITEHAProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITEHAProject.Controllers;

public class StaffController : Controller
{
    private readonly StaffService _staffService;

    public StaffController(StaffService staffService) // constructor for the staff service
    {
        _staffService = staffService;
    }

    private bool IsLoggedIn() // checks if the user is logged in
    {
        return HttpContext.Session.GetString("AdminUsername") != null;
    }

    public IActionResult Index() // shows the index page
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login", "Access");
        }
        return View(_staffService.GetAll());
    }

    [HttpGet]
    public IActionResult Create() // shows the create page
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login", "Access");
        }
        return View();
    }

    [HttpPost]
    public IActionResult Create(StaffMember staffMember) // creates a new staff member
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login", "Access");
        }
        _staffService.Add(staffMember);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id) // shows the edit page
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login", "Access");
        }
        var staffMember = _staffService.GetById(id);
        if (staffMember == null)
        {
            return RedirectToAction("Index");
        }
        return View(staffMember);
    }

    [HttpPost]
    public IActionResult Edit(StaffMember staffMember) // edits a staff member
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login", "Access");
        }
        _staffService.Update(staffMember);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id) // deletes a staff member
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login", "Access");
        }
        _staffService.Delete(id);
        return RedirectToAction("Index");
    }
}
