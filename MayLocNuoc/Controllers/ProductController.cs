using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MayLocNuoc.Controllers
{
    public class ProductController : Controller
    {
        // GET: mac dinh 
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //tr
        public ActionResult Index(string a)
        {
            return View();
        }
    }
}