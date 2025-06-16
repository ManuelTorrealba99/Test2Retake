using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Test2_Retake.Models;

[Table("Backpack")]
[PrimaryKey(nameof(CharacterId), nameof(ItemId))]
public class Backpack
{
    [ForeignKey(nameof(Character))]
    public int CharacterId { get; set; }
    [ForeignKey(nameof(Item))]
    public int ItemId { get; set; }
    public int Amount { get; set; }

    public Character Characters { get; set; } = null!;
    public Item Items { get; set; } = null!;
}