using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cakeryz.Models
{
    public class OrderProduct
    {
        public int OrderProductID { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }//if quantity >3 error message max quantity per item is 3
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
