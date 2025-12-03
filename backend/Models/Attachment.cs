using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Flowly.Api.Models;

public class Attachment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AttachmentId { get; set; }

    public int CardId { get; set; }
    public Card? Card { get; set; }
    [Required]
    [MaxLength(255)]
    public string FileName { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    public string FilePath { get; set; } = string.Empty;

    // bytes
    public int FileSize { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}
