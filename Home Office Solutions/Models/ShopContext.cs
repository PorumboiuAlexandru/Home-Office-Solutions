using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Office_Solutions.Models
{
    public class ShopContext : DbContext
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=HomeOfficeSolutions4;Trusted_Connection=False;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Shop> Shops { set; get; }
        public DbSet<StationaryItem> stationaryItems { set; get; }

        public DbSet<Stock> stocks { set; get; }
    }
}
