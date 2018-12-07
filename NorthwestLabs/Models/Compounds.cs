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
        public int? LTNumber { get; set; }

        [Display(Name = "Molecular Mass")]
        public double molecularMass { get; set; }

        [Display(Name = "Compound Name")]
        public string compoundName { get; set; }

        [Display(Name = "Appearance")]
        public string Appearance { get; set; }

        [Display(Name = "Max Tolerable Dose")]
        public double maxTolerableDose { get; set; }
    }
}