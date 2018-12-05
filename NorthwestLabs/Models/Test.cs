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

        [Display(Name = "Name")]
        public string testName { get; set; }

        [Display(Name = "Estimated Days")]
        public int estimatedDays { get; set; }

        [Display(Name = "Base Cost")]
        public double baseCost { get; set; }

        public ICollection<Assay> assays { get; set; }
        public ICollection<Material> materials { get; set; }
    }
}