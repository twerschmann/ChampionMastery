using Microsoft.EntityFrameworkCore;

namespace ChampionMastery.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mastery>().HasKey(m => new { m.championId, m.summonerId });
        modelBuilder.Entity<Summoner>().HasKey(s => s.id);
    }

    public DbSet<Summoner> Summoner { get; set; }

    public DbSet<Mastery> Mastery { get; set; }
}