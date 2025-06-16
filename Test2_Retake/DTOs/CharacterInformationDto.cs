using Test2_Retake.Models;

namespace Test2_Retake.DTOs;

public class CharacterInformationDto
{
    public string firstName { get; set; } = null!;
    public string lastName { get; set; } = null!;
    public int currentWeight { get; set; }
    public int maxWeight { get; set; }
    public List<BackpackItemDto> backpackItems { get; set; } = null!;
    public List<TitlesDto> titles { get; set; } = null!;
}

public class BackpackItemDto
{
    public string itemName { get; set; } = null!;
    public int itemWeight { get; set; }
    public int amount { get; set; }
}

public class TitlesDto
{
    public string title { get; set; } = null!;
    public DateTime aquiredAt { get; set; }
}