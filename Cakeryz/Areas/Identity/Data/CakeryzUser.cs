using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cakeryz.Areas.Identity.Data;

// Add profile data for application users by adding properties to the CakeryzUser class
public class CakeryzUser : IdentityUser
{
    
    

    [Required(ErrorMessage = "This field cannot be left empty")]
    [StringLength(35, ErrorMessage = "First name cannot be longer than 35 characters.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "This field cannot be left empty")]
    //[StringLength(35, ErrorMessage = "Last name cannot be longer than 35 characters.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Display(Name = "Shipping Address")]
    public string? ShippingAddress { get; set; }
    [Display(Name = "Billing Address")]
    public string? BillingAddress { get; set; }
    [Phone]
    [Display(Name = "Phone Number")]
    [StringLength(10, ErrorMessage = "Invalid Phone number")]
    public string? PhoneNumber { get; set; }
    [Display(Name = "Full Name")]
    public string FullName
    {
        get
        {
            return LastName + " " + FirstName;
        }
    }
}

