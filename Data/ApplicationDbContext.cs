using DailyNotes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DailyNotes.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<ReminderModel> Reminders { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for ReminderModel
        modelBuilder.Entity<ReminderModel>().HasData(
            new ReminderModel
            {
                Id = 1,
                Title = "Meeting Reminder",
                Content = "Don't forget the team meeting at 10 AM."
            },
            new ReminderModel
            {
                Id = 2,
                Title = "Doctor Appointment",
                Content = "Visit Dr. Smith at 3 PM."
            },
            new ReminderModel
            {
                Id = 3,
                Title = "Grocery Shopping",
                Content = "Buy milk, eggs, and bread."
            }
        );
    }

}