using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DailyNotes.Models;

public class ReminderModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    // Add UserId to relate to the ApplicationUser
    [Required]
    public string UserId { get; set; } = string.Empty;

    // Navigation property for the related user
    [ForeignKey("UserId")]
    public IdentityUser User { get; set; }
}