using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DailyNotes.Data;
using DailyNotes.Models;

namespace DailyNotes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public HomeController(
        ILogger<HomeController> logger,
        ApplicationDbContext context,
        UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        // Fetch reminders for the current user
        var userId = _userManager.GetUserId(User);
        var reminders = _context.Reminders.Where(r => r.UserId == userId).ToList();
        return View(reminders);
    }

    public IActionResult NewReminder()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ReminderModel reminder)
    {
        if (ModelState.IsValid)
        {
            var userId = _userManager.GetUserId(User);

            // Set the current user's ID on the reminder
            reminder.UserId = userId;

            // Save the reminder to the database
            _context.Reminders.Add(reminder);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View("NewReminder");
    }
}