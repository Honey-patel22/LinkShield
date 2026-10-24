using LinkShield.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LinkShield.Controllers;
public class DashboardController(AppDbContext db) : Controller
{
 public async Task<IActionResult> Index()
 {
  var scans = await db.ScanRecords.OrderByDescending(s => s.ScannedAt).Take(8).ToListAsync();
  ViewBag.Total = await db.ScanRecords.CountAsync(); ViewBag.High = await db.ScanRecords.CountAsync(s => s.RiskLevel == "High");
  ViewBag.Medium = await db.ScanRecords.CountAsync(s => s.RiskLevel == "Medium"); ViewBag.Low = await db.ScanRecords.CountAsync(s => s.RiskLevel == "Low");
  return View(scans);
 }
}
