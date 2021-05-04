using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Home_Office_Solutions.Models;

namespace Home_Office_Solutions.Models
{
    public class ShopContext : DbContext
    {
        /*private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=HomeOfficeSolutions10;Trusted_Connection=False;";*/
        private const string connectionString = "Server=tcp:homeofficesql.database.windows.net,1433;Initial Catalog=HomeOfficeSql;Persist Security Info=False;User ID=ad;Password=M@thes0n;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Shop> Shops { set; get; }
        public DbSet<StationaryItem> stationaryItems { set; get; }

        public DbSet<Stock> stocks { set; get; }

        public DbSet<Home_Office_Solutions.Models.StockShopAddress> StockShopAddress { get; set; }
    }
}
