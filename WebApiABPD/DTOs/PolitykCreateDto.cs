namespace WebApiABPD.DTOs;

public class PolitykCreateDto
{
    public string Imie { get; set; } = null!;
    public string Nazwisko { get; set; } = null!;
    public string? Powiedzenie { get; set; }

    public List<int>? Przynaleznosc { get; set; }
}