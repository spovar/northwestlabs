using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Models
{
    public class CompoundsController : Controller
    {
        // GET: Compounds
        public ActionResult Index()
        {
            return View();
        }
    }
}