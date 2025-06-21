using Microsoft.EntityFrameworkCore;
using WebApiABPD.Data;
using WebApiABPD.DTOs;
using WebApiABPD.Exceptions;
using WebApiABPD.Models;

namespace WebApiABPD.Services;

public interface IDbService
{
    public Task<ICollection<PolitykGetDto>> GetPolitycyAsync();
    public Task<PolitykGetDto> GetPolitykByIdAsync(int politykId);
    public Task<PolitykGetDto> CreatePolitykAsync(PolitykCreateDto politykData);
}

public class DbService(MyDbContext data) : IDbService
{
    public async Task<ICollection<PolitykGetDto>> GetPolitycyAsync()
    {
        var result = await data.Politycy
            .Include(p => p.Przynaleznosci)
            .ThenInclude(pz => pz.Partia)
            .Select(p => new PolitykGetDto
            {
                Id = p.Id,
                Imie = p.Imie,
                Nazwisko = p.Nazwisko,
                Powiedzenie = p.Powiedzenie,
                Przynaleznosc = p.Przynaleznosci.Select(pz => new PrzynaleznoscGetDto
                {
                    Nazwa = pz.Partia.Nazwa,
                    Skrot = pz.Partia.Skrot,
                    DataZalozenia = pz.Partia.DataZalozenia,
                    Od = pz.Od,
                    Do = pz.Do
                }).ToList()
            })
            .ToListAsync();

        return result;
    }

    public async Task<PolitykGetDto> GetPolitykByIdAsync(int politykId)
    {
        var result = await data.Politycy.Select(p => new PolitykGetDto
        {
            Id = p.Id,
            Imie = p.Imie,
            Nazwisko = p.Nazwisko,
            Powiedzenie = p.Powiedzenie,
            Przynaleznosc = p.Przynaleznosci.Select(pz => new PrzynaleznoscGetDto
            {
                Nazwa = pz.Partia.Nazwa,
                Skrot = pz.Partia.Skrot,
                DataZalozenia = pz.Partia.DataZalozenia,
                Od = pz.Od,
                Do = pz.Do
            }).ToList()
        }).FirstOrDefaultAsync(e => e.Id == politykId);
        return result ?? throw new NotFoundException($"Polityk with id {politykId} doesnt exists");
    }

    public async Task<PolitykGetDto> CreatePolitykAsync(PolitykCreateDto politykData)
    {
        var polityk = new Polityk
        {
            Imie = politykData.Imie,
            Nazwisko = politykData.Nazwisko,
            Powiedzenie = politykData.Powiedzenie
        };

        await data.Politycy.AddAsync(polityk);
        await data.SaveChangesAsync();

        var przynaleznosci = new List<Przynaleznosc>();

        if (politykData.Przynaleznosc is not null)
        {
            foreach (var partiaId in politykData.Przynaleznosc)
            {
                var partia = await data.Partie.FirstOrDefaultAsync(p => p.Id == partiaId);
                if (partia is null)
                    throw new NotFoundException($"Partia o ID {partiaId} nie istnieje");

                var przynaleznosc = new Przynaleznosc
                {
                    PartiaId = partia.Id,
                    PolitykId = polityk.Id,
                    Od = DateTime.Now,
                    Do = null
                };

                przynaleznosci.Add(przynaleznosc);
            }

            await data.Przynaleznosci.AddRangeAsync(przynaleznosci);
            await data.SaveChangesAsync();
        }

        return new PolitykGetDto
        {
            Id = polityk.Id,
            Imie = polityk.Imie,
            Nazwisko = polityk.Nazwisko,
            Powiedzenie = polityk.Powiedzenie,
            Przynaleznosc = przynaleznosci.Select(prz => new PrzynaleznoscGetDto
            {
                Nazwa = data.Partie.First(p => p.Id == prz.PartiaId).Nazwa,
                Skrot = data.Partie.First(p => p.Id == prz.PartiaId).Skrot,
                DataZalozenia = data.Partie.First(p => p.Id == prz.PartiaId).DataZalozenia,
                Od = prz.Od,
                Do = prz.Do
            }).ToList()
        };
    }
}