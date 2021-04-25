using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Office_Solutions.Models
{
    public enum ProductType { Notebook, Pen, Paper, Tape, Envelope, Diary }
    public class StationaryItem
    {
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "A Name is required for this field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A Product Type is required for this field")]
        public ProductType ProductType { get; set; }
        [Required(ErrorMessage = " A product brand/manufacturer is required for this field")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Product Color is required for this field")]
        public string Color { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }


    }
}
