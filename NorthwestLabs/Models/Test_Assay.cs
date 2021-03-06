﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    [Table("Test_Assay")]
    public class Test_Assay
    {
        [Key, Column(Order = 1)]
        public int? AssayID { get; set; }
        public virtual Assay Assays { get; set; }

        [Key, Column(Order = 2)]
        public int? TestID { get; set; }
        public virtual Test Tests { get; set; }

        public bool? Required;
    }
}