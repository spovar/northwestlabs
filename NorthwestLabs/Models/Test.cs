using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Models
{
    [Table("Test")]
    public class Test
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int TestID { get; set; }
        public int estimatedDays { get; set; }
        public double baseCost { get; set; }
    }
}