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
            /*Shop shop1 = new Shop() { ShopName = "das", ShopAddress = "dzxczasd" };
            Shop shop2 = new Shop() { ShopName = "dadsas", ShopAddress = "dascxzcd" };
            Shop shop3 = new Shop() { ShopName = "daeqw431s", ShopAddress = "davczxcsd" };

            ShopContext ctx = new ShopContext();
            ctx.Database.EnsureCreated();

            ctx.Shops.Add(shop1);
            ctx.Shops.Add(shop2);
            ctx.Shops.Add(shop3);*/

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
