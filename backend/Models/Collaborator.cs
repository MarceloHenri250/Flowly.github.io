using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Flowly.Api.Models;

public enum PermissionLevel
{
    View = 0,
    Edit = 1
}

public class Collaborator
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CollaboratorId { get; set; }

    public int BoardId { get; set; }
    public Board? Board { get; set; }

    // link to existing user
    public int UserId { get; set; }
    public User? User { get; set; }

    // 0 = view, 1 = edit
    public PermissionLevel Permission { get; set; } = PermissionLevel.View;

    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
}
