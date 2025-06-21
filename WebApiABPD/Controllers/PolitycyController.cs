using Microsoft.AspNetCore.Mvc;
using WebApiABPD.DTOs;
using WebApiABPD.Services;

namespace WebApiABPD.Controllers;

[ApiController]
[Route("[controller]")]
public class PolitycyController(IDbService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPolitycy()
    {
        return Ok(await service.GetPolitycyAsync());
    }

    [HttpGet("{politykId}")]
    public async Task<IActionResult> GetPolitykById(int politykId)
    {
        try
        {
            return Ok(await service.GetPolitykByIdAsync(politykId));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddPolityk([FromBody] PolitykCreateDto politykData)
    {
        try
        {
            var polityk = await service.CreatePolitykAsync(politykData);
            return CreatedAtAction(nameof(GetPolitycy), new { id = polityk.Id }, polityk);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}