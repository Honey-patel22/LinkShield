using Microsoft.AspNetCore.Mvc;
namespace LinkShield.Controllers;
public class ThreatsController : Controller
{
 public IActionResult Index(string? category) { var items = new[] {
 new Threat(1,"Phishing links","Social engineering","Fake pages imitate banks, delivery companies or campus portals to steal credentials.","🎣","Open the official app or type the known website address yourself."),
 new Threat(2,"Lookalike domains","Domain tricks","Attackers swap letters or add extra words to make a fake domain look familiar.","🪞","Read the domain from right to left and check the exact spelling."),
 new Threat(3,"Urgency & prize lures","Social engineering","Messages pressure you to act immediately or claim an unexpected reward.","⏱️","Pause and verify the message through a separate trusted channel."),
 new Threat(4,"Unencrypted pages","Connection security","HTTP does not encrypt the connection between your browser and a website.","🔓","Avoid submitting sensitive information on HTTP pages."),
 new Threat(5,"Suspicious downloads","Malware","A link may lead to an unexpected file or software installer.","📦","Do not run unexpected files; scan downloads and verify the sender."),
 new Threat(6,"Shortened URLs","Hidden destination","Short links can hide the website you will visit until you open them.","🔗","Confirm the sender and preview the destination with a trusted expander.")
 }; ViewBag.Category = category; return View(string.IsNullOrEmpty(category) ? items : items.Where(x => x.Category == category).ToArray()); }
 public record Threat(int Id, string Title, string Category, string Summary, string Icon, string Tip);
}
