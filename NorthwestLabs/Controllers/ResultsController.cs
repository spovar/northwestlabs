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
    public class ResultsController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();

        // GET: Results
        public ActionResult MyTestResults()
        {
            List<Results> resultslist = db.Results.ToList();

            foreach (var r2 in resultslist)
            {
                r2.compound = db.Database.SqlQuery<Compounds>("SELECT DISTINCT Compounds.LTNumber, Compounds.compoundName FROM Compounds INNER JOIN Results ON Compounds.LTNumber = Results.LTNumber WHERE Results.LTNumber = " + r2.LTNumber);
            }

            foreach (var r3 in resultslist)
            {
                r3.test = db.Database.SqlQuery<Test>("SELECT * FROM Test INNER JOIN Results on Results.TestID = Test.TestID WHERE Test.TestID = " + r3.TestID);
            }
            return View(resultslist);
        }

        public ActionResult labData()
        {
            List<Work_Order> compoundList = db.Work_Order.ToList();

            foreach (var c2 in compoundList)
            {
                c2.compounds = db.Database.SqlQuery<Compounds>("SELECT DISTINCT Compounds.LTNumber, Compounds.compoundName FROM Compounds INNER JOIN Work_Order ON Compounds.LTNumber = Work_Order.LTNumber WHERE Work_Order.LTNumber = " + c2.LTNumber);
            }

            return View(compoundList);
        }


        [HttpPost]
        public ActionResult labData(float weight)
        {
            db.Database.SqlQuery<Work_Order>("SELECT actualWeight FROM Work_Order");



            return View();
        }

        public ActionResult Index()
        {

            return View();
        }

        // GET: Results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = db.Results.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }

        // GET: Results/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestID,LTNumber,Result,Comments,employeePerforming")] Results results)
        {
            if (ModelState.IsValid)
            {
                db.Results.Add(results);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(results);
        }

        // GET: Results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = db.Results.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestID,LTNumber,Result,Comments,employeePerforming")] Results results)
        {
            if (ModelState.IsValid)
            {
                db.Entry(results).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(results);
        }

        // GET: Results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = db.Results.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Results results = db.Results.Find(id);
            db.Results.Remove(results);
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


       
        public ActionResult enterWeight(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Order work_Order = db.Work_Order.Find(id);
            if (work_Order == null)
            {
                return HttpNotFound();
            }
            return View(work_Order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult enterWeight(int orDErid, float acTual)
        {
              db.Work_Order.Find(orDErid).actualWeight = acTual;
                db.SaveChanges();
                return RedirectToAction("labData");
            
        }


    }
}