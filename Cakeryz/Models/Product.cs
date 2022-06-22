using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cakeryz.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        [StringLength(35, ErrorMessage = "Category name cannot be longer than 15 characters.")]
        public string Category { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        [StringLength(35, ErrorMessage = "Product name cannot be longer than 15 characters.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public OrderProduct OrderProduct { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        [Display(Name = " Production Cost")]
        public decimal ProductionCost { get; set; }//must be <$100
        [Required(ErrorMessage = "This field cannot be left empty")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        public decimal Profit { get; set; }


    }
}
