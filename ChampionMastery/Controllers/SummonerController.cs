using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChampionMastery.Models;
using ChampionMastery.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChampionMastery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummonerController : ControllerBase
    {
        private readonly DatabaseContext db;

        private readonly RiotApi riotApi;

        public SummonerController(DatabaseContext context)
        {
            riotApi = new RiotApi("euw1");
            db = context;
        }
        
        // GET: api/Summoner
        [HttpGet]
        public IEnumerable<Summoner> Get()
        {
            return db.Summoner;
        }

        // GET: api/Summoner/5
        [HttpGet("{id}", Name = "GetSummoner")]
        public ActionResult<Summoner> Get(string id)
        {
            var summonerInDb = db.Summoner.FirstOrDefault(s => s.name == id);

            if (summonerInDb != null) return summonerInDb;
            var summoner = riotApi.getSummonerByName(id);
                
            if (summoner == null)
            {
                return BadRequest();
            }
                
            db.Summoner.Add(summoner);
            db.SaveChanges();
            return summoner;
        }
    }
}
