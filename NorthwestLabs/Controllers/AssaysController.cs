﻿using System;
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
    public class AssaysController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();


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

        // GET: Assays
        public ActionResult Index()
        {
            return View(db.Assays.ToList());
        }

        // GET: Assays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assay assay = db.Assays.Find(id);
            if (assay == null)
            {
                return HttpNotFound();
            }
            return View(assay);
        }

        // GET: Assays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssayID,assayDescription")] Assay assay)
        {
            if (ModelState.IsValid)
            {
                db.Assays.Add(assay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assay);
        }

        // GET: Assays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assay assay = db.Assays.Find(id);
            if (assay == null)
            {
                return HttpNotFound();
            }
            return View(assay);
        }

        // POST: Assays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssayID,assayDescription")] Assay assay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assay);
        }

        // GET: Assays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assay assay = db.Assays.Find(id);
            if (assay == null)
            {
                return HttpNotFound();
            }
            return View(assay);
        }

        // POST: Assays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assay assay = db.Assays.Find(id);
            db.Assays.Remove(assay);
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
