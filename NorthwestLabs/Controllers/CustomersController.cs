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

           // work.LTNumber = random.Next(100000, 999999);


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
            ViewBag.compoundName = Session["CompNames"];

          return View();
        }

        [HttpPost]
        public ActionResult EnterAssay(bool? assay1, bool? assay2, bool? assay3, bool? assay4)
        {

            if (assay1 == null && assay2 == null && assay3 == null && assay4 == null){
                ViewBag.ErrorMessage = "<p align =\"center\" class=\"alert-danger myalert\" style=\"padding: 10px 20px; font - family:'Century Gothic'; font-size: 18px; border - radius:3px; \">Please Select an Assay</p></td>";
                return View();
            }
            //check if they want assay 1
            bool Economy = assay1 ?? false;
            if (Economy)
            {
                ViewBag.assay1 = "True";
            }
            //check if they want assay 2
            bool Economy2 = assay2 ?? false;
            if (Economy2)
            {
                ViewBag.assay2 = "True";
            }
            //check if they want assay 2
            bool Economy3 = assay3 ?? false;
            if (Economy3)
            {
                ViewBag.assay3 = "True";
            }
            //check if they want assay 2
            bool Economy4 = assay4 ?? false;
            if (Economy4)
            {                ViewBag.assay4 = "True";
            }


            ViewBag.compoundName = Session["CompNames"];
            Customer theCust =  db.Customers.Find(Session["CustomerID"]);


            return View("OrderConfirmation", theCust);
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
