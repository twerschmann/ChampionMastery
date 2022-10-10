using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using ChampionMastery.Models;

namespace ChampionMastery.Services;

public class RiotApi
{
    private readonly string API_KEY = "RGAPI-abffd856-232a-4eb4-a23d-f508e7211d70";

    private readonly string URL;

    private HttpClient client;
    
    public RiotApi(string region)
    {
        //euw1
        URL = $"https://{region}.api.riotgames.com";

        client = new HttpClient();
        client.BaseAddress = new Uri(URL);

        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        
        client.DefaultRequestHeaders.Add("X-Riot-Token",API_KEY);
    }

    public Summoner getSummonerByName(string summonerName)
    {
        var summonerUrl = $"/lol/summoner/v4/summoners/by-name/{summonerName}";

        var response = client.GetAsync(summonerUrl).Result;

        if (response.IsSuccessStatusCode)
        {
            var summoner = response.Content.ReadFromJsonAsync<Summoner>().Result;

            if (summoner != null) return summoner;
        }
        
        return null;
    }

    public IEnumerable<Mastery> GetMasteriesBySummonerId(string summonerId)
    {
        var masteryUrl = $"/lol/champion-mastery/v4/champion-masteries/by-summoner/{summonerId}";

        var response = client.GetAsync(masteryUrl).Result;

        if (response.IsSuccessStatusCode)
        {
            var masteries = response.Content.ReadFromJsonAsync<IEnumerable<Mastery>>().Result;

            if (masteries != null) return masteries;
        }

        return null;
    }
}

