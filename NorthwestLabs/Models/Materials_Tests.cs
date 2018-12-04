using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Models
{
    [Table("Materials_Tests")]
    public class Materials_Tests
    {
        [Key, Column(Order = 1)]
        public int? MaterialsID { get; set; }
        public virtual Material Materials { get; set; }

        [Key, Column(Order = 2)]
        public int? TestID { get; set; }
        public virtual Test Tests { get; set; }
    }
}