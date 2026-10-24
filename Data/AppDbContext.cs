using LinkShield.Models;
using Microsoft.EntityFrameworkCore;
namespace LinkShield.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
 public DbSet<ScanRecord> ScanRecords => Set<ScanRecord>();
 public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();
 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
  base.OnModelCreating(modelBuilder);
  modelBuilder.Entity<ScanRecord>().HasIndex(x => x.ScannedAt);
 }
}
