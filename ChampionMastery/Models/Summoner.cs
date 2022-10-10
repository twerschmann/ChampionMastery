﻿using System.ComponentModel.DataAnnotations;

namespace ChampionMastery.Models;

public class Summoner
{
    public string accountId { get; set; }
    
    public int profileIconId { get; set; }
    
    public long revisionDate { get; set; }
    
    public string name { get; set; }
    
    [Key]
    public string id { get; set; }
    
    public string puuid { get; set; }
    
    public long summonerLevel { get; set; }
    
    public List<Mastery> Mastery { get; set; }
}