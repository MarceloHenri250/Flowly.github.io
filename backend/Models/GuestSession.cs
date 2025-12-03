using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Flowly.Api.Models;

public class GuestSession
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GuestSessionId { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public DateTime ExpiresAt { get; set; }
}
