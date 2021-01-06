using CovidStats.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CovidStats.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CovidStastsController : ControllerBase
    {
        private readonly CovidStatsDataContext context;

        public CovidStastsController(CovidStatsDataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("states")]
        public IEnumerable<FederalState> GetFederalStates() => context.FederalStates;

        [HttpGet]
        [Route("states/{stateId}/cases")]
        public IEnumerable<CovidCases> GetStates([FromRoute] int stateId) => context.CovidCases
            .Where(c => c.District.State.ID == stateId)
            .Include(c => c.District);

        [HttpGet]
        [Route("cases")]
        public IEnumerable<TotalCases> GetCases() => context.TotalCases;

        //[HttpPost]
        //[Route("importData")]
        //public async Task ImportData()
        //{
        //    HttpClient http = new HttpClient();
            
        //    if (!context.FederalStates.Any() && !context.Districts.Any())
        //    {
        //        string[] lines = (await http.GetStringAsync("http://www.statistik.at/verzeichnis/reglisten/polbezirke.csv")).Split("\n");

        //        var skiped = lines.Skip(3).Skip(2);



        //    }
        //}
    }
}
