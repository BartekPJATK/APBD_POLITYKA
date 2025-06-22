using Microsoft.EntityFrameworkCore;
using WebApiABPD.Models;

namespace WebApiABPD.Data;

public class MyDbContext: DbContext
{
    public DbSet<Partia> Partie { get; set; }
    public DbSet<Polityk> Politycy { get; set; }
    public DbSet<Przynaleznosc> Przynaleznosci { get; set; }
    
    public MyDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Partia>().HasData(
            new Partia {Id = 99, Nazwa = "Partia Przykladowa", Skrot = "PP", DataZalozenia = new DateTime(1990, 1, 1) }
        );

        modelBuilder.Entity<Polityk>().HasData(
            new Polityk {Id = 99, Imie = "Jan", Nazwisko = "Kowalski", Powiedzenie = "Obywatelu, spokojnie!" }
        );

        modelBuilder.Entity<Przynaleznosc>().HasData(
            new Przynaleznosc {Id = 99, PartiaId = 99, PolitykId = 99, Od = new DateTime(2010, 1, 1), Do = null }
        );
    }
}