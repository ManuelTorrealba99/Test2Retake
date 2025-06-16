using Test2_Retake.DTOs;

namespace Test2_Retake.Services;

public interface IDbService
{
    Task<CharacterInformationDto> GetCharacterInformationByIdAsync(int id);
    Task AddCharacterInventoryAsync(int id, CharacterInventoryRequestDto dto);
}