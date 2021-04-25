using Home_Office_Solutions.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Office_Solutions
{
    public class Program
    {
        public static void Main(string[] args)
        {

            StationaryItem stat1 = new StationaryItem() {Name ="£", ProductType= ProductType.Diary, Brand= "das", Color = "sad"};
            StationaryItem stat2 = new StationaryItem() { Name = "£wqeq", ProductType = ProductType.Diary, Brand = "das", Color = "sad" };
            StationaryItem stat3 = new StationaryItem() { Name = "£das", ProductType = ProductType.Diary, Brand = "das", Color = "sad" };

            ShopContext txz = new ShopContext();
            txz.Database.EnsureCreated();
            txz.stationaryItems.Add(stat1);
            txz.stationaryItems.Add(stat2);
            txz.stationaryItems.Add(stat3);
            txz.SaveChanges();
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
