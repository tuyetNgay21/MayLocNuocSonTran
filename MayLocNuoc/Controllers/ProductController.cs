using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MayLocNuoc.Models;
using PagedList;

namespace MayLocNuoc.Controllers
{
    public class ProductController : Controller
    {
        mayLocNuocEntities db = new mayLocNuocEntities();
        // GET: mac dinh 
        public ActionResult Index(int page=1, int size=12)
        {
            var model = db.sanphams.OrderBy(n=>n.soluong).ToPagedList(page, size);
            return View(model);
        }
        public ActionResult IndexG(int page = 1, int size = 12)
        {
            var model = (from c in db.sanphams orderby c.gia descending select c).ToPagedList(page, size);
            return View(model);
        }
        public ActionResult IndexT(int page = 1, int size = 12)
        {
            var model = (from c in db.sanphams orderby c.gia ascending select c).ToPagedList(page, size);
            return View(model);
        }
        public ActionResult IndexGG(int page = 1, int size = 12)
        {
            var model = (from c in db.sanphams where c.sophantram>=50 orderby c.gia descending select c).ToPagedList(page, size);
            return View(model);
        }
        public ActionResult IndexGG1(int page = 1, int size = 12)
        {
            var model = (from c in db.sanphams where c.sophantram <= 50 && c.sophantram>=30 orderby c.gia descending select c).ToPagedList(page, size);
            return View(model);
        }
        public ActionResult IndexGG2(int page = 1, int size = 12)
        {
            var model = (from c in db.sanphams where c.sophantram <= 30 && c.sophantram >= 10 orderby c.gia descending select c).ToPagedList(page, size);
            return View(model);
        }
        public ActionResult IndexGG3(int page = 1, int size = 12)
        {
            var model = (from c in db.sanphams where c.sophantram <= 10  orderby c.gia descending select c).ToPagedList(page, size);
            return View(model);
        }
        public ActionResult IndexS(string TimKiem ,int page = 1, int size = 12)
        {
            if (TimKiem == null)
            {
                var model = db.f_TimKiemTheoTen(TimKiem).OrderBy(n => n.gia).ToPagedList(page, size);
                return View(model);
            }
            else
            {
                if (TimKiem.Contains("@") == true || TimKiem.Contains("&") == true ||
                               TimKiem.Contains("{") == true || TimKiem.Contains("$") == true ||
                               TimKiem.Contains("}") == true || TimKiem.Contains("%") == true ||
                               TimKiem.Contains("<") == true || TimKiem.Contains(">") == true ||
                               TimKiem.Contains("#") == true || TimKiem.Contains("!") == true ||
                               TimKiem.Contains("?") == true || TimKiem.Contains(";") == true)
                {
                    return RedirectToAction("Error", "Error1");
                }
                else{
                    var model = db.f_TimKiemTheoTen(TimKiem).OrderBy(n => n.gia).ToPagedList(page, size);
                    return View(model);
                }

            }

        }
    }
}