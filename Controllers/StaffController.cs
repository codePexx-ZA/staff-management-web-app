using ITEHAProject.Models;
using ITEHAProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITEHAProject.Controllers;

public class StaffController : Controller
{
    private readonly StaffService _staffService;

    public StaffController(StaffService staffService)
    {
        _staffService = staffService;
    }

    private bool IsLoggedIn()
    {
        return HttpContext.Session.GetString("AdminUsername") != null;
    }

    public IActionResult Index()
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login", "Access");
        }
        return View(_staffService.GetAll());
    }

    [HttpGet]
    public IActionResult Create()
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login", "Access");
        }
        return View();
    }

    [HttpPost]
    public IActionResult Create(StaffMember staffMember)
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login", "Access");
        }
        _staffService.Add(staffMember);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
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
    public IActionResult Edit(StaffMember staffMember)
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login", "Access");
        }
        _staffService.Update(staffMember);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login", "Access");
        }
        _staffService.Delete(id);
        return RedirectToAction("Index");
    }
}
