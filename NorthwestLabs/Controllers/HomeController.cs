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
            ViewBag.Message = "About Us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Services";

            return View();
        }

        public ActionResult Catalog()
        {
            List<Assay> myAssays = db.Assays.ToList();

            foreach (var assay in myAssays)
            {
                assay.tests = db.Database.SqlQuery<Test>("SELECT * FROM Test INNER JOIN Test_Assay ON Test.TestID = Test_Assay.TestID WHERE Test_Assay.AssayID = " + assay.AssayID);
                ViewBag.materials = db.Database.SqlQuery<Material>("SELECT * FROM Materials");
            }


            return View(myAssays);
        }
    }
}