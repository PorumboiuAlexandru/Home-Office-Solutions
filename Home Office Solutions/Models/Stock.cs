using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Office_Solutions.Models
{
    public class Stock
    {
        [Required]
        public int StockID { get; set; }
        public int ProductID { get; set; }
        public int ShopID { get; set; }
        [Required]
        public double Price { get; set; }

        public virtual Shop Shop { set; get; }
        public virtual StationaryItem StationaryItem { set; get; }

        


    }
}
