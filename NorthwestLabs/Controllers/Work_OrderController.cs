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
    public class Work_OrderController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();

        // GET: Work_Order
        public ActionResult Index()
        {
            List<Work_Order> woList = db.Work_Order.ToList();
            foreach (var wo in woList)
            {
                List custwoList
            }
            return View(db.Work_Order.ToList());
        }

        public ActionResult MyWorkOrders()
        {
            return View(db.Work_Order.ToList());
        }

        /*Index()
	{
		List<Faculty> mylist = db.Faculties.ToList();

		foreach (var faculty in mylist) {
			faculty.subject = db.Database.SqlQuery<Subject>("SELECT SubjectName FROM Subjects INNER JOIN Faculty_Subjects ON Faculty_Subjects.SubjectID = Subjects.SubjectID WHERE StaffID = " + faculty.StaffID);
		}

		return View(mylist);
	}*/

        // GET: Work_Order/Details/5
        public ActionResult Details(int? id)
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

        // GET: Work_Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Work_Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustomerID,LTNumber,Status,dateArrived,dateDue,custWeight,actualWeight,Quantity")] Work_Order work_Order)
        {
            if (ModelState.IsValid)
            {
                db.Work_Order.Add(work_Order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(work_Order);
        }

        // GET: Work_Order/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Work_Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerID,LTNumber,Status,dateArrived,dateDue,custWeight,actualWeight,Quantity")] Work_Order work_Order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_Order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work_Order);
        }

        // GET: Work_Order/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Work_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Work_Order work_Order = db.Work_Order.Find(id);
            db.Work_Order.Remove(work_Order);
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
