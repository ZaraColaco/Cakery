using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cakeryz.Areas.Identity.Data;

namespace Cakeryz.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        [Display(Name = "Customer")]
        [Required]
        public int CakeryUserID { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-mmm-yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime DatePlaced { get; set; }//date time now function
        [Required]
        [Display(Name = "Delivery or Pickup?")]
        public string DeliveryorPickup { get; set; }//dropdown
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-mmm-yyyy hh:mm}", ApplyFormatInEditMode = true)]//probaby change it to a drop down list
        [Display(Name = "Collection Slot")]
        public DateTime CollectionDate { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        [Display(Name = "Status")]
        public string Status{ get; set; }//dropdown
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Payment Received?")]
        public DateTime Paydate { get; set; }//date time picker

        public CakeryzUser CakeryzUser { get; set; }
        public OrderProduct OrderProduct { get; set; }
    

    }
}
