using LinkShield.Data;
using LinkShield.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LinkShield.Controllers;
public class HistoryController(AppDbContext db) : Controller
{
 public async Task<IActionResult> Index(string? q, string? risk) { var rows = db.ScanRecords.AsQueryable(); if (!string.IsNullOrWhiteSpace(q)) rows = rows.Where(s => s.Url.Contains(q)); if (!string.IsNullOrWhiteSpace(risk)) rows = rows.Where(s => s.RiskLevel == risk); ViewBag.Query = q; ViewBag.Risk = risk; return View(await rows.OrderByDescending(s => s.ScannedAt).ToListAsync()); }
 public async Task<IActionResult> Details(int id) { var row = await db.ScanRecords.FindAsync(id); return row == null ? NotFound() : View(row); }
 public async Task<IActionResult> Edit(int id) { var row = await db.ScanRecords.FindAsync(id); return row == null ? NotFound() : View(row); }
 [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Edit(int id, [Bind("Id,Url")] ScanRecord input) { if (id != input.Id) return NotFound(); if (!ModelState.IsValid) return View(input); var row = await db.ScanRecords.FindAsync(id); if (row == null) return NotFound(); row.Url = input.Url; var a = LinkShield.Services.UrlRiskAnalyzer.Analyze(input.Url); row.RiskScore = a.Score; row.RiskLevel = a.Level; row.Findings = string.Join("|", a.Findings); row.ScannedAt = DateTime.Now; await db.SaveChangesAsync(); TempData["Message"] = "Scan record updated."; return RedirectToAction(nameof(Index)); }
 public async Task<IActionResult> Delete(int id) { var row = await db.ScanRecords.FindAsync(id); return row == null ? NotFound() : View(row); }
 [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken] public async Task<IActionResult> DeleteConfirmed(int id) { var row = await db.ScanRecords.FindAsync(id); if (row != null) { db.ScanRecords.Remove(row); await db.SaveChangesAsync(); TempData["Message"] = "Scan record deleted."; } return RedirectToAction(nameof(Index)); }
}
