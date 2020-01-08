using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MayLocNuoc.Controllers
{
    public class DaMuaController : Controller
    {
        
        // GET: DaMua
        public ActionResult DangMua()
        {
            return View();
        }
        public ActionResult LichSu()
        {
            return View();
        }
    }
}