using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cakeryz.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        [StringLength(35, ErrorMessage = "First name cannot be longer than 35 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        [StringLength(35, ErrorMessage = "Last name cannot be longer than 35 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; }
        [Required(ErrorMessage = "This field cannot be left empty")]
        [Display(Name = "Billing Address")]
        public string BillingAddress { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "This field cannot be left empty")]
        [StringLength(10, ErrorMessage = "Invalid Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
        public Order Order { get; set; }
    }
}
