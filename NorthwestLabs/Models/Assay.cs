using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NorthwestLabs.Models
{
    [Table("Assay")]
    public class Assay
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int AssayID { get; set; }

        public string assayDescription { get; set; }
    }
}