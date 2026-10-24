# LinkShield — Smart URL Safety Checker

A responsive ASP.NET Core MVC mini-project for the Web Technologies with .NET course. It demonstrates MVC routing, EF Core with MySQL, CRUD operations, form validation, session-based state management and a responsive UI.

> **Important:** LinkShield is an educational demo. Its rule-based score is not a guarantee that a website is safe and does not replace a security product. The account pages use session state for demonstration only; they are not production authentication and do not store passwords.

## Pages included
1. Home / URL scanner
2. Scan result with score and explanations
3. Dashboard and statistics
4. Scan history with search and risk filter
5. Scan details
6. Edit scan record
7. Delete confirmation
8. Threat education library with category filters
9. About and technology stack
10. FAQ
11. Contact form (saved to MySQL)
12. Demo login
13. Demo registration

## Technology stack
- ASP.NET Core MVC (.NET 8)
- C# models and controllers
- Entity Framework Core 8
- MySQL with Pomelo EF Core provider
- Razor Views, HTML5, CSS, JavaScript
- ASP.NET Core Session for demo user state

## Requirements
- .NET 8 SDK
- MySQL Server 8.x (or compatible)
- Visual Studio 2022 or VS Code

## Setup on Windows / Visual Studio
1. Install .NET 8 SDK and MySQL Server.
2. Open `appsettings.json` and replace `YOUR_MYSQL_PASSWORD` with your local MySQL password. Keep the connection string local; do not commit real passwords to GitHub.
3. Create the database in MySQL:

   ```sql
   CREATE DATABASE linkshield_db;
   ```

4. Open a terminal in the folder containing `LinkShield.csproj` and run:

   ```powershell
   dotnet restore
   dotnet tool install --global dotnet-ef
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   dotnet run
   ```

5. Open the HTTPS or HTTP URL printed in the terminal.

If `dotnet-ef` is already installed, skip the tool-install command. If your global tool path is not on PATH, restart the terminal after installation.

## What is stored in MySQL?
- `ScanRecords`: submitted URL, heuristic score, risk category, explanations, timestamp and demo session name.
- `ContactMessages`: contact form submissions.

## CRUD demonstration
- **Create:** submit a URL from the Home page.
- **Read:** Dashboard, History, Result and Details pages.
- **Update:** History → Edit. The URL is re-analysed on save.
- **Delete:** History → Delete, then confirm.
- Contact messages are created after server-side validation.

## Rule-based URL analysis
The analyzer checks for patterns such as HTTP instead of HTTPS, raw IP hosts, punycode hostnames, suspicious words in paths/queries, many hyphens, unusually deep subdomains, user-info before `@`, and unusually long URLs. It does not contact the destination website.

## Session state
The demo login stores a display name and email in ASP.NET Core Session. Session expires after 30 minutes of inactivity. The account form is intentionally labelled demo-only and should not be presented as secure authentication.

## Troubleshooting
- **Database connection fails:** confirm MySQL is running, the password is correct, and `linkshield_db` exists.
- **No tables:** run `dotnet ef migrations add InitialCreate` followed by `dotnet ef database update`.
- **Port already in use:** run `dotnet run --urls http://localhost:5090`.
- **NuGet restore fails:** check internet connectivity and retry `dotnet restore`.

## Poster content suggestion (A2 portrait)
**Problem:** Suspicious links can impersonate trusted services and trick people into sharing sensitive information.

**Objective:** Build an explainable URL-checking web app that demonstrates common warning signals and teaches safe browsing habits.

**Architecture:** Browser (Razor UI) → MVC Controller → Rule-based URL Analyzer → EF Core → MySQL. Session middleware stores demo user state.

**Modules:** URL scanner, risk report, dashboard, scan-history CRUD, threat library, demo session, contact form, FAQ/about.

**Result:** URL checks are categorized into Low/Medium/High based on configured heuristic points; scans and contact messages persist in MySQL.

**Conclusion:** The prototype demonstrates full-stack MVC fundamentals and cyber-awareness education. The heuristic score is illustrative and does not certify a URL as safe.

Capture real screenshots of the running app for the poster: Home scanner, result page, dashboard, history CRUD and threat library. Avoid placing database passwords or private credentials in screenshots.
