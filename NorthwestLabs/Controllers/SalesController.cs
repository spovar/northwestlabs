using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NorthwestLabs.DAL;
using NorthwestLabs.Models;

namespace NorthwestLabs.Controllers
{
    public class SalesController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();

        public ActionResult Quote()
        {
            //Get List of Assays, send it to the view for the drop down list
            return View(db.Assays.ToList());
        }

        [HttpPost]
        public ActionResult Quote(int? ID, int? weight)
        {
            Assay quoteAssay = db.Assays.Find(ID);
            double cost = 0;
            double weightcost = 0;

            //Connect quoteassay to its respective tests
            quoteAssay.tests = db.Database.SqlQuery<Test>("SELECT * FROM Test INNER JOIN Test_Assay ON Test.TestID = Test_Assay.TestID INNER JOIN Assay ON Assay.AssayID = Test_Assay.AssayID WHERE Assay.AssayID = " + quoteAssay.AssayID);
            Session["Assay"] = quoteAssay.assayDescription;

            //Loops through each tests and adds up the cost
            foreach (var i in quoteAssay.tests)
            {
                cost = cost + i.baseCost;
            }
            Session["TestCost"] = cost;

            //Returns base cost of assay
            Session["BaseCost"] = 500;

            //Set the variable weight cost
            Session["WeightCost"] = 0;
            if (weight >= 100)
            {
                weightcost = 50;
            }
            else if (weight >= 50)
            {
                weightcost = 25;
            }

            Session["WeightCost"] = weightcost;
            Session["Weight"] = weight;
            Session["TotalCost"] = 500 + cost + weightcost;
            return RedirectToAction("QuoteSummary");
        }

        public ActionResult QuoteSummary()
        {
            ViewBag.assay = Session["Assay"];
            ViewBag.testcost = Session["TestCost"];
            ViewBag.basecost = Session["BaseCost"];
            ViewBag.weight = Session["Weight"];
            ViewBag.weightcost = Session["WeightCost"];
            ViewBag.totalcost = Session["TotalCost"];
            return View();
        }
    }
}

