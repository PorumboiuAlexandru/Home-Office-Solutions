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
        [Display(Name = "Product Name")]
        public int ProductID { get; set; }
        [Display(Name = "Shop Name")]
        public int ShopID { get; set; }
        [Required]
        [Display(Name = "Price €")]
        public double Price { get; set; }

        public virtual Shop Shop { set; get; }
        public virtual StationaryItem StationaryItem { set; get; }

        


    }
}
