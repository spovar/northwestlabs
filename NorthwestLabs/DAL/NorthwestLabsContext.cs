using NorthwestLabs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NorthwestLabs.DAL
{
    public class NorthwestLabsContext : DbContext
    {
        //Context page setting DBSets to connection string
        public NorthwestLabsContext() : base("DefaultConnection")
        {

        }
        public DbSet<Compounds> Compounds { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Assay> Assays { get; set; }
        public DbSet<Test_Assay> Test_Assay { get; set; }
        public System.Data.Entity.DbSet<NorthwestLabs.Models.Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<NorthwestLabs.Models.Work_Order> Work_Order { get; set; }

        public System.Data.Entity.DbSet<NorthwestLabs.Models.Results> Results { get; set; }
    }
}