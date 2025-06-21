using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiABPD.Models;

//id, partia id, polityk id od do

[Table("Przynaleznosc")]
public class Przynaleznosc
{
    [Column("ID")] [Key] public int Id { get; set; }
    
    [Column("Partia_ID")] public int PartiaId { get; set; }
    [Column("Polityk_ID")] public int PolitykId { get; set; }
    
    public DateTime Od { get; set; }
    public DateTime? Do { get; set; }
    
    [ForeignKey(nameof(PartiaId))]
    public virtual Partia Partia { get; set; } = null!;
    [ForeignKey(nameof(PolitykId))]
    public virtual Polityk Polityk { get; set; } = null!;
}