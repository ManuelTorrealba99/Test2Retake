using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2_Retake.Models;

[Table("Item")]
public class Item
{
    [Key]
    public int ItemId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    [MaxLength(100)]
    public int Weight { get; set; }

    public ICollection<Backpack> Backpacks { get; set; } = null!;
}