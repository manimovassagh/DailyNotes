using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DailyNotes.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedReminderData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reminders",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[,]
                {
                    { 1, "Don't forget the team meeting at 10 AM.", "Meeting Reminder" },
                    { 2, "Visit Dr. Smith at 3 PM.", "Doctor Appointment" },
                    { 3, "Buy milk, eggs, and bread.", "Grocery Shopping" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reminders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reminders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reminders",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
