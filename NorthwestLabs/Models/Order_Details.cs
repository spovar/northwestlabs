using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    public class Order_Details
    {

        [Key, Column(Order = 1)]
        public int? OrderID { get; set; }
        public virtual Work_Order Work_Order { get; set; }

        [Key, Column(Order = 2)]
        public int? AssayID { get; set; }
        public virtual Assay Assay { get; set; }

        public bool? Included { get; set; }
    }
}