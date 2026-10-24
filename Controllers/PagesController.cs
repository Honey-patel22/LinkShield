using LinkShield.Data;
using LinkShield.Models;
using Microsoft.AspNetCore.Mvc;
namespace LinkShield.Controllers;
public class PagesController(AppDbContext db) : Controller
{
 public IActionResult Contact() => View();
 [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Contact(ContactMessage model) { if (!ModelState.IsValid) return View(model); db.ContactMessages.Add(model); await db.SaveChangesAsync(); TempData["Message"] = "Thanks — your message has been saved."; return RedirectToAction(nameof(Contact)); }
}
