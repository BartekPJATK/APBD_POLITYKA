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
}