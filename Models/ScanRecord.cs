using System.ComponentModel.DataAnnotations;
namespace LinkShield.Models;
public class ScanRecord
{
    public int Id { get; set; }
    [Required, StringLength(2048), Url(ErrorMessage = "Enter a valid URL including https:// or http://")]
    [Display(Name = "Website URL")]
    public string Url { get; set; } = "";
    [StringLength(30)] public string RiskLevel { get; set; } = "Low";
    [Range(0,100)] public int RiskScore { get; set; }
    [StringLength(1200)] public string Findings { get; set; } = "";
    public DateTime ScannedAt { get; set; } = DateTime.Now;
    [StringLength(100)] public string? SubmittedBy { get; set; }
}
