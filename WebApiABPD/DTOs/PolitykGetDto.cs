namespace WebApiABPD.DTOs;

public class PolitykGetDto
{
    public int Id { get; set; }
    public string Imie { get; set; } = null!;
    public string Nazwisko { get; set; } = null!;
    public string? Powiedzenie { get; set; }
    
    public List<PrzynaleznoscGetDto> Przynaleznosc { get; set; } = new();
}