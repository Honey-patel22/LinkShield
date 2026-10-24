using LinkShield.Data;
using LinkShield.Models;
using LinkShield.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LinkShield.Controllers;
public class HomeController(AppDbContext db) : Controller
{
 public IActionResult Index() => View();
 [HttpPost, ValidateAntiForgeryToken]
 public async Task<IActionResult> Scan([Bind("Url")] ScanRecord input)
 {
  if (!ModelState.IsValid) return View("Index", input);
  var analysis = UrlRiskAnalyzer.Analyze(input.Url);
  input.RiskScore = analysis.Score; input.RiskLevel = analysis.Level; input.Findings = string.Join("|", analysis.Findings); input.ScannedAt = DateTime.Now;
  input.SubmittedBy = HttpContext.Session.GetString("UserName") ?? "Guest";
  db.ScanRecords.Add(input); await db.SaveChangesAsync();
  HttpContext.Session.SetInt32("LastScanId", input.Id);
  return RedirectToAction("Result", new { id = input.Id });
 }
 public async Task<IActionResult> Result(int id) { var scan = await db.ScanRecords.FindAsync(id); return scan == null ? NotFound() : View(scan); }
 public IActionResult About() => View();
 public IActionResult FAQ() => View();
 public IActionResult Error() => View();
}
