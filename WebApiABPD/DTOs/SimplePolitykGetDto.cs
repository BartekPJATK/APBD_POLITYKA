namespace WebApiABPD.DTOs;

public class SimplePolitykGetDto
{
    public int Id { get; set; }
    public string Imie { get; set; } = null!;
    public string Nazwisko { get; set; } = null!;
    public string? Powiedzenie { get; set; }
}