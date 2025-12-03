using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Flowly.Api.Models;

public class Column
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ColumnId { get; set; }

    public int BoardId { get; set; }
    public Board? Board { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = "Column";

    public int Position { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Card> Cards { get; set; } = new List<Card>();
}
