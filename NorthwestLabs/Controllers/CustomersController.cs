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
    public class CustomersController : Controller
    {
        Random random = new Random();
        private NorthwestLabsContext db = new NorthwestLabsContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,firstName,lastName,Company,Address,City,State,Zip,Email,Phone,discountRate")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();

                Session["CustomerID"] = customer.CustomerID;
                /*Work_Order work = new Work_Order();
                work.CustomerID = customer.CustomerID;
                db.Work_Order.Add(work);
                db.SaveChanges();
                
                work = db.Work_Order.ElementAt(4);
                */
             //   work.OrderID = db.Database.SqlQuery<Work_Order>("SELECT MAX(OrderID) FROM Work_Order WHERE CustomerID = " + work.CustomerID);


                return RedirectToAction("EnterCompound");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerID,firstName,lastName,companyName,streetAddress,city,state,zip,email,phone,discountRate")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EnterCompound()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EnterCompound(string compName, float compWeight, int compQuant)
        {

            Work_Order work = new Work_Order();
            work.custWeight = compWeight;
            work.Quantity = compQuant;

            ViewBag.whatever = Session["CustomerID"];
            work.CustomerID = ViewBag.whatever;

            work.LTNumber = random.Next(100000, 999999);


            Compounds comp = new Compounds();

            comp.LTNumber = work.LTNumber;
            comp.compoundName = compName;

            db.Work_Order.Add(work);
            db.Compounds.Add(comp);

            db.SaveChanges();


            Session["CompNames"] = comp.compoundName;
            ViewBag.compoundName = comp.compoundName;
            return RedirectToAction("EnterAssay");

        }    

        public ActionResult EnterAssay()
        {
            List<Assay> assay =  db.Assays.ToList();
            Order_Details orderdeets = new Order_Details();

            foreach(var item in assay)
            {
                orderdeets.AssayID = item.AssayID;
                orderdeets.OrderID = ??????????
                db.Order_Details.Add();
                db.SaveChanges();
            }

            return View(db.Order_Details.ToList());
        }

        [HttpPost]
        public ActionResult EnterAssay(bool? happy)
        {
           // var orderNum = db.Work_Order.Find(id);

            if (orderNum != null)
            {


                bool Economy = chkeco ?? false;
                if (Economy)
                {
                    ViewBag.Invoice = "True";
                }
                else
                {
                    ViewBag.Invoice = null;
                }


                ViewBag.OrderNum = orderNum.OrderID;
                return View();

            }
            ViewBag.Load = null;
            ViewBag.OrderNum = null;
            return View();
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
