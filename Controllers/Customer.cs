using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DailyNotes.Models;

namespace DailyNotes.Controllers;

public class CustomerController(ILogger<HomeController> logger): Controller
{
    
    private readonly ILogger<HomeController> _logger;


    public IActionResult Custom()
    {
        return View();
    }

    
}