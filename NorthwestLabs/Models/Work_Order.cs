using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Models
{
    [Table("Work_Order")]
    public class Work_Order
    {
        [Key]
        public int OrderID { get; set; }
        public int LTNumber { get; set; }

        public string Status { get; set; }

        [Display(Name = "Date Arrived")]
        public DateTime dateArrived { get; set; }

        [Display(Name = "Due Date")]
        public DateTime dateDue { get; set; }

        [Display(Name = "Weight")]
        public double custWeight { get; set; }

        [Display(Name = "Actual Weight")]
        public double actualWeight { get; set; }

        [Display(Name = "Quantity (mg)")]
        public double Quantity { get; set; }

        public IEnumerable<Compounds> compounds { get; set; }

        public int CustomerID { get; set; }
        public IEnumerable<Customers> compounds { get; set; }
    }
}