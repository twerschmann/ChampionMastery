using System.ComponentModel.DataAnnotations;

namespace ChampionMastery.Models;

public class Mastery
{
    public long championPointsUntilNextLevel { get; set; }
    
    public bool chestGranted { get; set; }
    
    [Key]
    public long championId { get; set; }
    
    public long lastPlayTime { get; set; }
    
    public int championLevel { get; set; }

    [Key]
    public string summonerId { get; set; }
    
    public int championPoints { get; set; }
    
    public long championPointsSinceLastLevel { get; set; }

    public int tokensEarned { get; set; }

    public Summoner Summoner;

}