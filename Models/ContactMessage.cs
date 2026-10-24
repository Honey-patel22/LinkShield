using System.ComponentModel.DataAnnotations;
namespace LinkShield.Models;
public class ContactMessage
{
 public int Id { get; set; }
 [Required, StringLength(80)] public string Name { get; set; } = "";
 [Required, EmailAddress, StringLength(150)] public string Email { get; set; } = "";
 [Required, StringLength(1000, MinimumLength=10)] public string Message { get; set; } = "";
 public DateTime CreatedAt { get; set; } = DateTime.Now;
}
