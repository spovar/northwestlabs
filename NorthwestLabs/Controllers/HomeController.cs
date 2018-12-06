using NorthwestLabs.DAL;
using NorthwestLabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    //Alec Bawden, Isaac McDougal, Sam Povar, Kevin Nelson
    //Intex project
    public class HomeController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Catalog()
        {
            List<Assay> myAssays = db.Assays.ToList();

            foreach(var assay in myAssays)
            {
                assay.tests = db.Database.SqlQuery<Test>("SELECT testName FROM Test INNER JOIN Test_Assay ON Test.TestID = Test_Assay.TestID WHERE Assay.AssayID = " + assay.AssayID);
            }

            return View(myAssays);
        }
    }
}