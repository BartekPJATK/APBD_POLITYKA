using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApiABPD.Models;

[Table("Polityk")]
public class Polityk
{
    [Column("ID")] [Key] public int Id { get; set; }
    [MaxLength(50)] public string Imie { get; set; } = null!;
    [MaxLength(100)] public string Nazwisko { get; set; } = null!;
    [MaxLength(200)] public string? Powiedzenie { get; set; }
    
    public virtual ICollection<Przynaleznosc> Przynaleznosci { get; set; } = null!;
}