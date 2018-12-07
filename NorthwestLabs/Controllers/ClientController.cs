using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NorthwestLabs.DAL;
using NorthwestLabs.Models;

namespace NorthwestLabs.Controllers
{
    [Authorize(Roles = "Client")]
    public class ClientController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();

        //Shows a client their test results
        public ActionResult MyTestResults()
        {
            List<Results> resultslist = db.Results.ToList();

            //Join the compound data to the results data
            foreach (var r2 in resultslist)
            {
                r2.compound = db.Database.SqlQuery<Compounds>("SELECT DISTINCT Compounds.LTNumber, Compounds.compoundName FROM Compounds INNER JOIN Results ON Compounds.LTNumber = Results.LTNumber WHERE Results.LTNumber = " + r2.LTNumber);
            }

            //Join the test data to the results data
            foreach (var r3 in resultslist)
            {
                r3.test = db.Database.SqlQuery<Test>("SELECT * FROM Test INNER JOIN Results on Results.TestID = Test.TestID WHERE Test.TestID = " + r3.TestID);
            }
            return View(resultslist);
        }

        //Shows a client their work orders
        public ActionResult MyWorkOrders()
        {
            var custList = from c in db.Work_Order select c;

            //Filter cust list to only show orders where customerID = 1
            custList = custList.Where(c => c.CustomerID == 1);
            return View(custList);
        }
    }
}
