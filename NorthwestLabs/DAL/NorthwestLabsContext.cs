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

        public DbSet<Material> Materials { get; set; }
    }
}