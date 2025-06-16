using System.Data;
using Test2_Retake.Data;
using Test2_Retake.DTOs;
using Test2_Retake.Exceptions;
using Microsoft.EntityFrameworkCore;
using Test2_Retake.Models;

namespace Test2_Retake.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<CharacterInformationDto> GetCharacterInformationByIdAsync(int id)
    {
        var result = await _context.Characters.Where(e => e.CharacterId == id)
            .Select(e => new CharacterInformationDto
            {
                firstName = e.FisrtName,
                lastName = e.LastName,
                currentWeight = e.CurrentWeight,
                maxWeight = e.MaxWeight,
                backpackItems = e.Backpacks.Select(e => new BackpackItemDto()
                {
                    itemName = e.Items.Name,
                    itemWeight = e.Items.Weight,
                    amount = e.Amount
                }).ToList(),
                titles = e.CharacterTitles.Select(e => new TitlesDto()
                {
                    title = e.Titles.Name,
                    aquiredAt = e.AcquiredAt
                }).ToList()
            }).FirstOrDefaultAsync();
        
        if (result is null)
            throw new NotFoundException();
        
        return result;
    }

    public async Task AddCharacterInventoryAsync(int id, CharacterInventoryRequestDto dto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var character = await _context.Characters.FirstOrDefaultAsync(e => e.CharacterId == id);
            
            foreach (var item in dto.CharacterIds)
            {
                var itemsExist = await _context.Items.FirstOrDefaultAsync(e => e.ItemId == item);
                if  (itemsExist is null)
                    throw new NotFoundException("Item " + item + " not found");
                
                var itemWeight = await _context.Items.FirstOrDefaultAsync(e => e.ItemId == item);

                int weight = itemWeight.Weight + character.CurrentWeight;
                
                if (weight > character.MaxWeight)
                    throw new Exception("Maximum weight exceed");

                var newBackpack = new Backpack()
                {
                    CharacterId = id,
                    ItemId = item,
                    Amount = 1,
                };
                
                _context.Backpacks.Add(newBackpack);

                if (weight < character.MaxWeight)
                {
                    character.CurrentWeight = weight;
                }
            }
            
            
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            
        }
        catch (Exception ex)
        { 
            await transaction.RollbackAsync(); 
            throw; 
        }
    }

}