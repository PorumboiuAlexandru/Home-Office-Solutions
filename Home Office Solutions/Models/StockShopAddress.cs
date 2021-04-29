using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Office_Solutions.Models
{
    public class StockShopAddress
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int ShopID { get; set; }
        
        public string ShopAddress { get; set; }
        
        public string ShopName { get; set; }
        public double Price { get; set; }
        public int StockID { get; set; }
    }
}
