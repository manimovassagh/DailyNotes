using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DailyNotes.Models;
using DailyNotes.Data;

namespace DailyNotes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        // Fetch all reminders from the database
        var reminders = _context.Reminders.ToList();
        return View(reminders);
    }

    // Action to display the "Add New Reminder" page
    public IActionResult NewReminder()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ReminderModel reminder)
    {
        if (ModelState.IsValid)
        {
            // Add the reminder to the database
            _context.Reminders.Add(reminder);
            _context.SaveChanges();

            // Redirect to Index to show updated list
            return RedirectToAction("Index");
        }

        // If model validation fails, stay on the NewReminder page
        return View("NewReminder");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}