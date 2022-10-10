using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChampionMastery.Models;
using ChampionMastery.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChampionMastery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasteryController : ControllerBase
    {
        private readonly DatabaseContext db;

        private readonly RiotApi riotApi;
        
        public MasteryController(DatabaseContext context)
        {
            db = context;

            riotApi = new RiotApi("euw1");
        }
        
        // GET: api/Mastery
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mastery/5
        [HttpGet("test/{id}", Name = "GetMastery")]
        public ActionResult<IEnumerable<Mastery>> Get(string id)
        {

            var masteries = riotApi.GetMasteriesBySummonerId(id);

            if (masteries == null) return BadRequest();
            

            return new ActionResult<IEnumerable<Mastery>>(masteries);
            
            
        }

        [HttpGet("BySummonerName/{summonerName}")]
        public ActionResult<IEnumerable<Mastery>> GetMasteryBySummonerName(string summonerName)
        {
            return new ActionResult<IEnumerable<Mastery>>(new List<Mastery>());
        }
    }
}
