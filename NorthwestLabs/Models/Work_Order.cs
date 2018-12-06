using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    public class Work_Order
    {

        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int LTNumber { get; set; }
        public string Status { get; set; }
        public DateTime dateArrived { get; set; }
        public DateTime dateDue { get; set; }
        public double custWeight { get; set; }
        public double actualWeight { get; set; }
        public string MyProperty { get; set; }
    }
}