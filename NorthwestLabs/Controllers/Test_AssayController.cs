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
    public class Test_AssayController : Controller
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

        public ActionResult Index()
        {
            var test_Assay = db.Test_Assay.Include(t => t.Assays).Include(t => t.Tests);
            return View(test_Assay.ToList());
        }

        // GET: Test_Assay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Assay test_Assay = db.Test_Assay.Find(id);
            if (test_Assay == null)
            {
                return HttpNotFound();
            }
            return View(test_Assay);
        }

        // GET: Test_Assay/Create
        public ActionResult Create()
        {
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "assayDescription");
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "testName");
            return View();
        }

        // POST: Test_Assay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssayID,TestID")] Test_Assay test_Assay)
        {
            if (ModelState.IsValid)
            {
                db.Test_Assay.Add(test_Assay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "assayDescription", test_Assay.AssayID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "testName", test_Assay.TestID);
            return View(test_Assay);
        }

        // GET: Test_Assay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Assay test_Assay = db.Test_Assay.Find(id);
            if (test_Assay == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "assayDescription", test_Assay.AssayID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "testName", test_Assay.TestID);
            return View(test_Assay);
        }

        // POST: Test_Assay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssayID,TestID")] Test_Assay test_Assay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test_Assay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssayID = new SelectList(db.Assays, "AssayID", "assayDescription", test_Assay.AssayID);
            ViewBag.TestID = new SelectList(db.Tests, "TestID", "testName", test_Assay.TestID);
            return View(test_Assay);
        }

        // GET: Test_Assay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Assay test_Assay = db.Test_Assay.Find(id);
            if (test_Assay == null)
            {
                return HttpNotFound();
            }
            return View(test_Assay);
        }

        // POST: Test_Assay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test_Assay test_Assay = db.Test_Assay.Find(id);
            db.Test_Assay.Remove(test_Assay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
