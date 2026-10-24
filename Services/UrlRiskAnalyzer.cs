namespace LinkShield.Services;
public record RiskAnalysis(int Score, string Level, string[] Findings);
public static class UrlRiskAnalyzer
{
 public static RiskAnalysis Analyze(string rawUrl)
 {
  var findings = new List<string>(); int score = 0;
  if (!Uri.TryCreate(rawUrl, UriKind.Absolute, out var uri)) return new(0, "Unknown", new[] { "The URL could not be parsed. Check the address and try again." });
  if (uri.Scheme != Uri.UriSchemeHttps) { score += 20; findings.Add("The address does not use HTTPS encryption."); }
  var host = uri.Host.ToLowerInvariant();
  if (IsIpAddress(host)) { score += 25; findings.Add("The link uses a raw IP address instead of a familiar domain."); }
  if (host.StartsWith("xn--") || host.Contains(".xn--")) { score += 20; findings.Add("The domain uses internationalized characters that may imitate another website."); }
  var suspiciousWords = new[] { "verify", "login", "secure", "account", "update", "wallet", "password", "gift", "prize", "free" };
  if (suspiciousWords.Any(w => uri.AbsolutePath.Contains(w, StringComparison.OrdinalIgnoreCase) || uri.Query.Contains(w, StringComparison.OrdinalIgnoreCase))) { score += 15; findings.Add("The URL contains account, verification, or reward-related wording often used in lures."); }
  if (host.Count(c => c == '-') >= 3) { score += 10; findings.Add("The domain contains several hyphens, which can be used in deceptive lookalike names."); }
  if (host.Split('.').Length >= 5) { score += 10; findings.Add("The domain has an unusually deep subdomain structure."); }
  if (uri.UserInfo.Length > 0) { score += 25; findings.Add("The address includes text before the @ symbol that can disguise the actual destination."); }
  if (rawUrl.Length > 100) { score += 5; findings.Add("The URL is unusually long and may hide its destination or tracking parameters."); }
  if (findings.Count == 0) findings.Add("No configured warning patterns were detected. This does not guarantee that the website is safe.");
  score = Math.Clamp(score, 0, 100);
  var level = score >= 50 ? "High" : score >= 25 ? "Medium" : "Low";
  return new(score, level, findings.ToArray());
 }
 private static bool IsIpAddress(string host) => System.Net.IPAddress.TryParse(host, out _);
}
