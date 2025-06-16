using Test2_Retake.Exceptions;
using Test2_Retake.Services;
using Microsoft.AspNetCore.Mvc;
using Test2_Retake.DTOs;

namespace Test2_Retake.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;

    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCharacterInformation(int id)
    {
        try
        {
            var order = await _dbService.GetCharacterInformationByIdAsync(id);
            return Ok(order);
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
    }
    
    [HttpPost("{id}/backpacks")]
    public async Task<IActionResult> AddCharacterInventory(int id, CharacterInventoryRequestDto dto)
    {
        try
        {
            await _dbService.AddCharacterInventoryAsync(id, dto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
    }
}