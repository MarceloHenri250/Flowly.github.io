using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flowly.Api.Models;

public class Board
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BoardId { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = "New board";

    // Owner FK -> Users.UserId
    public int OwnerId { get; set; }
    public User? Owner { get; set; }

    [MaxLength(20)]
    public string? Color { get; set; }

    // 0 = none, 1 = básico, 2 = estudos, etc.
    public int TemplateType { get; set; } = 0;

    public DateTime? LastAccessedAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Column> Columns { get; set; } = new List<Column>();
    public ICollection<Collaborator> Collaborators { get; set; } = new List<Collaborator>();
}
