using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Flowly.Api.Models;

public class Card
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CardId { get; set; }

    public int ColumnId { get; set; }
    public Column? Column { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;
    // text / long description
    public string? Description { get; set; }

    // 0 = baixa, 1 = média, 2 = alta
    public int Priority { get; set; } = 0;

    public DateTime? DueDate { get; set; }

    // position inside the column
    public int Position { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
}
