using NorthwestLabs.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    public class AdminController : Controller
    {

        private NorthwestLabsContext db = new NorthwestLabsContext();

        // GET: Admin
        public ActionResult Index()
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

    }
}