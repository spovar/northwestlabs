using NorthwestLabs.DAL;
using NorthwestLabs.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();

        public ActionResult LabInfo()
        {
            return View();
        }

        public ActionResult ViewReports()
        {
            ViewBag.Load = "yes";
            return View();
        }

        [HttpPost]
        public ActionResult ViewReports(int? id, bool? chkeco)
        {
            var orderNum = db.Work_Order.Find(id);
            
            if (orderNum != null){


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

        public ActionResult labData()
        {
            List<Work_Order> compoundList = db.Work_Order.ToList();

            foreach (var c2 in compoundList)
            {
                c2.compounds = db.Database.SqlQuery<Compounds>("SELECT DISTINCT * FROM Compounds INNER JOIN Work_Order ON Compounds.LTNumber = Work_Order.LTNumber WHERE Work_Order.LTNumber = " + c2.LTNumber);
            }

            return View(compoundList);
        }

        [HttpPost]
        public ActionResult labData(float weight)
        {
            db.Database.SqlQuery<Work_Order>("SELECT actualWeight FROM Work_Order");
            return View();
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