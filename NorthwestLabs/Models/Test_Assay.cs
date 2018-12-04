using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwestLabs.Models
{
    public class Test_Assay
    {
        public int AssayID;
        public Assay Assays = new Assay();

        public int TestID;
        public Test Tests = new Test();
        public bool? required;
    }
}