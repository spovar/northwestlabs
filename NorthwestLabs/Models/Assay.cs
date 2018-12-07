using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace NorthwestLabs.Models
{
    [Table("Assay")]
    public class Assay
    {
        [Key]
        public int AssayID { get; set; }

        [Display(Name = "Description")]
        public string assayDescription { get; set; }

        public IEnumerable<Test> tests { get; set; }
        public IEnumerable<Material> materials { get; set; }
    }
}