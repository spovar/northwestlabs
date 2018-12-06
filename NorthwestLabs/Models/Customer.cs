using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int customerID { get; set; }

        [Required(ErrorMessage = "The First Name is required.")]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Please enter your first name.")]
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "The Last Name is required.")]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Please enter your last name.")]
        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "The company name is required.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Please enter the company name.")]
        [DisplayName("Company Name")]
        public string companyName { get; set; }

        [Required(ErrorMessage = "The street address is required.")]
        [DisplayName("Street Address")]
        public string streetAddress { get; set; }

        [Required(ErrorMessage = "The city is required.")]
        [DisplayName("City")]
        public string city { get; set; }

        [Required(ErrorMessage = "The state is required.")]
        [DisplayName("State")]
        public string state { get; set; }

        [Required(ErrorMessage = "The zip code is required.")]
        [RegularExpression(@"^\d{5}([\-]\d{4})?$")]
        [DisplayName("Zip Code")]
        public int zip { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter Correct Email Address")]
        [DisplayName("Email Address")]
        public string email { get; set; }

        [RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")]
        [DisplayName("Phone Number")]
        public int phone { get; set; }

        [Range(0, 75)]
        [HiddenInput(DisplayValue = false)]
        public float discountRate { get; set; }
    }
}