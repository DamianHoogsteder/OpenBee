using MarketService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketService.DAL
{
    public class MarketDatabaseContext : DbContext
    {
        public MarketDatabaseContext(DbContextOptions<MarketDatabaseContext> opt) :base(opt)
        {
        }

        public DbSet<Market> Markets { get; set; }
        public DbSet<Items> Items { get; set; }
    }
}
