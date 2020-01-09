using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MayLocNuoc.Models;

namespace MayLocNuoc.Controllers
{
    public class DaMuaController : Controller
    {
        mayLocNuocEntities db = new mayLocNuocEntities();
        // GET: DaMua
        public ActionResult DangMua()
        {
            if(save.taikhoan==null || save.taikhoan == "")
            {
                return RedirectToAction("Log", "DangNhap");
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult LichSu()
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("Log", "DangNhap");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Shearch(string id)
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("Log", "DangNhap");
            }
            else
            {
                if(id==null || id=="")
                {
                    return RedirectToAction("Error", "Error1");
                }
                else
                {
                    try
                    {
                        var MaSanPham = Convert.ToInt32(id);
                        mayLocNuocEntities db = new mayLocNuocEntities();
                        var dangmua = db.daMuas.Where(n => n.taikhoan == save.taikhoan && n.idDM == MaSanPham).ToList();
                        return View(dangmua);

                    }
                    catch (Exception)
                    {
                        return RedirectToAction("Error", "Error1");
                    }
                   
                }
            }
        }

        [HttpPost]

        public JsonResult XoaSanPhamDaMua(string id)
        {
            /*
             * 1 Hệ Thống Bị Lỗi
             * 2 dang van chuyen khong the huy
             * 3 thanh cong
             */
            string Trave = "";
            try
            {
               var madamua= Convert.ToInt32(id);
                if(db.daMuas.Where(n=>n.idDM==madamua).FirstOrDefault().dangVanChuyen==true)
                {
                    Trave = "2";
                }
                else
                {
                    var gf = db.daMuas.Where(n => n.idDM == madamua).FirstOrDefault();
                    gf.daxoa = true;
                    db.SaveChanges();
                    Trave = "3";
                }
            }
            catch (Exception)
            {

                Trave = "1";
            }
            return Json(Trave);
        }

        public JsonResult SanPhamDaXoaCanKhoiPhuc(string id)
        {
            /*
             * 1 Hệ Thống Bị Lỗi
             * 2 dang van chuyen khong the huy
             * 3 thanh cong
             */
            string Trave = "";
            try
            {
                var madamua = Convert.ToInt32(id);
                if (db.daMuas.Where(n => n.idDM == madamua).FirstOrDefault().dangVanChuyen == true)
                {
                    Trave = "2";
                }
                else
                {
                    var gf = db.daMuas.Where(n => n.idDM == madamua).FirstOrDefault();
                    gf.daxoa = false;
                    db.SaveChanges();
                    Trave = "3";
                }
            }
            catch (Exception)
            {

                Trave = "1";
            }
            return Json(Trave);
        }
    }
}