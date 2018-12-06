using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Models
{
    [Table("Materials")]
    public class Material
    {
       [Key]
       [HiddenInput(DisplayValue = false)]
        public int MaterialsID { get; set; }

        public string materialsDescription { get; set; }

        public double materialsCost { get; set; }

        public IEnumerable<Test> tests { get; set; }
    }
}