# LINKSHIELD — SMART URL SAFETY CHECKER
## Problem statement
Suspicious URLs are often used in phishing messages, lookalike domains and misleading offers. Users may click before checking the destination.

## Objectives
- Accept and validate a URL through an accessible web form.
- Apply transparent, rule-based warning checks.
- Show a risk score, category and human-readable findings.
- Save scan history and support Create, Read, Update and Delete operations.
- Provide practical online-threat education.

## Technology stack
ASP.NET Core MVC · C# · Entity Framework Core · MySQL · Pomelo provider · Razor Views · HTML · CSS · JavaScript · ASP.NET Core Session

## System architecture
User/browser → Razor view → MVC controller → URL risk analyzer → EF Core → MySQL. Session middleware keeps demo user state between requests.

## Implemented modules
Home scanner · Result report · Dashboard statistics · Scan history/search/filter · Scan details · Edit/Delete · Threat education · Demo login/register · Contact form · About · FAQ

## Results
The prototype identifies configured URL patterns and categorizes scores as Low (0–24), Medium (25–49) or High (50–100). Scan records and contact submissions are persisted in MySQL.

## Conclusion
LinkShield demonstrates full-stack MVC concepts while making online safety signals easier to understand. It is a learning prototype, not a live threat-intelligence service; a low score does not guarantee safety.

## Screenshot placeholders to replace with real screenshots
1. Home URL scanner
2. Example scan result
3. Dashboard statistics
4. History page showing edit/delete actions
5. Threat education library
