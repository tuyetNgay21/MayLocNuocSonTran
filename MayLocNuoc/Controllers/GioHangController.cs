using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MayLocNuoc.Models;

namespace MayLocNuoc.Controllers
{
    public class GioHangController : Controller
    {
        mayLocNuocEntities db = new mayLocNuocEntities();
        // GET: GioHang
        public ActionResult MyCart()
        {
            if(save.taikhoan==null || save.taikhoan=="")
            {
                return RedirectToAction("Log", "DangNhap");
            }
            else
            {
                return View();
            }            
        }

        [HttpPost]
        public JsonResult addProduct( string idGioHang, string soluong)
        {

            /*
             * 1 loi he thong
             * 2 gio hang tim ko thay na pham cos tai khoan va ma hang nhu tren 
             * 3 tai khoan chua dang nhap
             * 4 la thanh cong chuyen den trang da mua 
             */
            string trave = "";
            if (save.taikhoan==""|| save.taikhoan==null) {
               trave="3";
            }
            else
            {
                try
                {
                    int concac = Convert.ToInt32(idGioHang);
                    var bcg = db.dangMuas.Where(n => n.taikhoan == save.taikhoan && n.idDM == concac);
                    if (bcg.Count() == 0)
                    {
                        trave = "2";
                    }
                    else
                    {
                        daMua dam = new daMua();
                        dam.soluong = Convert.ToInt32(soluong);
                        dam.gia = bcg.FirstOrDefault().gia;
                        dam.sophantram = bcg.FirstOrDefault().sophantram;
                        dam.dangChuanBi = true;
                        dam.ngaymua = DateTime.Now;
                        dam.ngayLapDat = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0));
                        dam.dangVanChuyen = false;
                        dam.daxoa = false;
                        dam.idSP = bcg.FirstOrDefault().idSP;
                        dam.taikhoan = save.taikhoan;

                        db.daMuas.Add(dam);

                        db.SaveChanges();
                        bcg.FirstOrDefault().daxoa = true;
                        db.SaveChanges();
                        trave = "4";
                    }
                }
                catch (Exception)
                {

                    trave = "1";
                }
            }
            return Json(trave);
        } 

        public JsonResult Deletes(string idGioHang)
        {
            /*
            * 1 loi he thong
            * 2 gio hang tim ko thay na pham cos tai khoan va ma hang nhu tren 
            * 3 tai khoan chua dang nhap
            * 4 la thanh cong and thong bao
            */
            string trave = "";
            if (save.taikhoan == "" || save.taikhoan == null)
            {
                trave = "3";
            }
            else
            {
                try
                {
                    int concac = Convert.ToInt32(idGioHang);
                    var bcg = db.dangMuas.Where(n => n.taikhoan == save.taikhoan && n.idDM == concac);
                    if (bcg.Count() == 0)
                    {
                        trave = "2";
                    }
                    else
                    {
                        bcg.FirstOrDefault().daxoa = true;
                        db.SaveChanges();
                        trave = "4";
                    }
                }
                catch (Exception)
                {

                    trave = "1";
                }
            }
            return Json(trave);
        }
    }
}