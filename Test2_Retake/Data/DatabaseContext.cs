using Microsoft.EntityFrameworkCore;
using Test2_Retake.Models;

namespace Test2_Retake.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(new List<Item>()
        {
            new Item() { ItemId = 1, Name = "Item1", Weight = 10 },
            new Item() { ItemId = 2, Name = "Item2", Weight = 11 },
            new Item() { ItemId = 3, Name = "Item3", Weight = 12},
        });
        
        modelBuilder.Entity<Title>().HasData(new List<Title>()
        {
            new Title() { TitleId = 1, Name = "Title1" },
            new Title() { TitleId = 2, Name = "Title2" },
            new Title() { TitleId = 3, Name = "Title3" },
        });
        
        modelBuilder.Entity<Character>().HasData(new List<Character>()
        {
            new Character() { CharacterId = 1, FisrtName = "John", LastName = "Yakuza", CurrentWeight = 43, MaxWeight = 200},
            new Character() { CharacterId = 2, FisrtName = "Peter", LastName = "Lewis", CurrentWeight = 81, MaxWeight = 120 },
            new Character() { CharacterId = 3, FisrtName = "Juan", LastName = "Baustista", CurrentWeight = 11, MaxWeight = 80 },
        });
        
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>()
        {
            new Backpack() { ItemId = 1, CharacterId = 1, Amount = 2},
            new Backpack() { ItemId = 2, CharacterId = 1, Amount = 1},
            new Backpack() { ItemId = 3, CharacterId = 1, Amount = 1},
        });
        
        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>()
        {
            new CharacterTitle() { CharacterId = 1, TitleId = 1, AcquiredAt = new DateTime(2024,06,10)},
            new CharacterTitle() { CharacterId = 1, TitleId = 2, AcquiredAt = new DateTime(2024,06,08)},
            new CharacterTitle() { CharacterId = 1, TitleId = 3, AcquiredAt = new DateTime(2024,06,09)},
        });
    }
}