using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Flowly.Api.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Email { get; set; } = string.Empty;

    // nullable: null if registered via Google
    public string? PasswordHash { get; set; }

    public string? GoogleId { get; set; }

    public bool IsGuest { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? LastLogin { get; set; }

    public ICollection<Board> Boards { get; set; } = new List<Board>();
    public ICollection<Collaborator> Collaborations { get; set; } = new List<Collaborator>();
    public ICollection<GuestSession> GuestSessions { get; set; } = new List<GuestSession>();
}
