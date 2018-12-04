using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Models
{
    [Table("Compounds")]
    public class Compounds
    {

        [Key]
        [HiddenInput(DisplayValue = false)]
        public int LTNumber { get; set; }

        public float molecularMass { get; set; }

        public string compoundName { get; set; }

        public string Appearance { get; set; }

        public float maxTolerableDose { get; set; }
    }
}