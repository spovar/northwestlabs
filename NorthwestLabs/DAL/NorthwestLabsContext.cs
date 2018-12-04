using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NorthwestLabs.DAL
{
    public class NorthwestLabsContext : DbContext
    {
        //Testing - Alec @ 11:43 AM
        public NorthwestLabsContext() : base("DefaultContext")
        {

        }
    }
}