using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DailyNotes.Models;

namespace DailyNotes.Controllers;

public class CustomerController(ILogger<CustomerController> logger) : Controller
{
    private readonly ILogger<CustomerController> _logger = logger;



    public IActionResult Custom()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}