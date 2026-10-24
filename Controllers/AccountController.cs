using Microsoft.AspNetCore.Mvc;
namespace LinkShield.Controllers;
public class AccountController : Controller
{
 public IActionResult Login() => View(); public IActionResult Register() => View();
 [HttpPost, ValidateAntiForgeryToken] public IActionResult Login(string name, string email) { if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || !email.Contains('@')) { ViewBag.Error = "Enter your name and a valid email."; return View(); } HttpContext.Session.SetString("UserName", name.Trim()); HttpContext.Session.SetString("UserEmail", email.Trim()); return RedirectToAction("Index", "Dashboard"); }
 [HttpPost, ValidateAntiForgeryToken] public IActionResult Register(string name, string email, string password) { if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || !email.Contains('@') || string.IsNullOrWhiteSpace(password) || password.Length < 6) { ViewBag.Error = "Enter a name, valid email, and password with at least 6 characters."; return View(); } HttpContext.Session.SetString("UserName", name.Trim()); HttpContext.Session.SetString("UserEmail", email.Trim()); return RedirectToAction("Index", "Dashboard"); }
 public IActionResult Logout() { HttpContext.Session.Clear(); return RedirectToAction("Index", "Home"); }
}
