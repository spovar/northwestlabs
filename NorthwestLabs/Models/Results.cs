using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    [Table("Results")]
    public class Results
    {
        [Key, Column (Order = 1)]
        public int TestID { get; set; }

        [Key, Column(Order = 2)]
        public int LTNumber { get; set; }

        [Display(Name = "Pass?")]
        public bool Result { get; set; }

        public string Comments { get; set; }
        public int employeePerforming { get; set; }

        public IEnumerable<Test> test { get; set; }
        public IEnumerable<Compounds> compound { get; set; }
    }
}