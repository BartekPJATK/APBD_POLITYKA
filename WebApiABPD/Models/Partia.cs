using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiABPD.Models;

[Table("Partia")]
public class Partia
{
    [Column("ID")]
    [Key]
    public int Id { get; set; }

    [MaxLength(300)]
    public string Nazwa { get; set; } = null!;
    
    [MaxLength(10)]
    public string? Skrot { get; set; }
    public DateTime DataZalozenia { get; set; }

    public virtual ICollection<Przynaleznosc> Przynaleznosci { get; set; } = null!;
}