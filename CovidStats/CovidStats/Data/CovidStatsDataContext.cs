using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidStats.Data
{
    public class CovidStatsDataContext : DbContext
    {
        public CovidStatsDataContext(DbContextOptions<CovidStatsDataContext> options)
       : base(options)
        { }

        public DbSet<District> Districts { get; set; }
        public DbSet<FederalState> FederalStates { get; set; }
        public DbSet<CovidCases> CovidCases { get; set; }
        public DbSet<TotalCases> TotalCases { get; set; }

    }
}
