using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MayLocNuoc.Models;

namespace MayLocNuoc.Controllers
{
    public class QuanTriController : Controller
    {
        mayLocNuocEntities db = new mayLocNuocEntities();
        // GET: QuanTri
        public ActionResult DN()
        {
            return View();
        }


        [HttpPost]
        public JsonResult checkDN(string a, string p)
        {
            string trave = "";
            try
            {
                var pa = MD5.ToMD5(p.Trim());
                var tontai = db.accs.Where(n => n.taikhoan == a && n.matkhau == pa).Count();
                if (tontai == 1)
                {
                    var kiemtra = db.accs.Where(n => n.taikhoan == a).FirstOrDefault();
                    if (kiemtra.chucvu == 0)
                    {
                        save.taikhoan = a;
                        HttpCookie ck = new HttpCookie("Máy Lọc Nước Sơn Trần");
                        ck.Value = maHoa.mahoa(a + "1507" + MD5.ToMD5(p));
                        ck.Expires = DateTime.Now.AddDays(15);
                        Response.Cookies.Add(ck);
                        trave = "2";//admintoicao
                    }
                    else if (kiemtra.chucvu == 1)
                    {
                        save.taikhoan = a;
                        HttpCookie ck = new HttpCookie("Máy Lọc Nước Sơn Trần");
                        ck.Value = maHoa.mahoa(a + "1507" + MD5.ToMD5(p));
                        ck.Expires = DateTime.Now.AddDays(15);
                        Response.Cookies.Add(ck);
                        trave = "3";//admin
                    }
                    else if (kiemtra.chucvu == 2)
                    {
                        save.taikhoan = a;
                        HttpCookie ck = new HttpCookie("Máy Lọc Nước Sơn Trần");
                        ck.Value = maHoa.mahoa(a + "1507" + MD5.ToMD5(p));
                        ck.Expires = DateTime.Now.AddDays(15);
                        Response.Cookies.Add(ck);
                        trave = "4";//nhacungcap
                    }
                    else
                    {
                        trave = "5";
                    }
                }
                else
                {
                    trave = "1";
                }
            }
            catch (Exception)
            {
                //goi ve gmail bao cho quan ly biet loi he thong nam dau
                trave = "0";
            }

            return Json(trave);
        }

        public JsonResult laymk(string taikhoan, string gmail)
        {
            string trave = "";
            if (taikhoan == null || taikhoan == "" || gmail == null || gmail == "")
            {
                trave = "3";
            }
            else
            {
                try
                {
                    Ran a = new Ran();
                    int songaunhien = a.songaunhien();
                    guiMail g = new guiMail();
                    var taiKhoanLayDuoc = db.accs.Where(n => n.taikhoan == taikhoan.Trim() && n.email == gmail.Trim());
                    if(taiKhoanLayDuoc.Count()==1)
                    {
                        if (g.ToguiMail(gmail, Convert.ToString(songaunhien).Trim()) == true)
                        {

                            taiKhoanLayDuoc.FirstOrDefault().matkhau = MD5.ToMD5(Convert.ToString(songaunhien).Trim());
                            db.SaveChanges();
                            trave = "1";
                        }
                        else
                        {
                            //gui mail den tai khoan cua ban
                            trave = "2";
                        }
                    }
                    else
                    {
                        trave = "0";
                    }
                    

                }
                catch (Exception)
                {

                    trave = "2";
                }
            }
            return Json(trave);
        }


        public JsonResult doimk(string taikhoan, string mkcu, string mkmoi)
        {
            string trave = "";
            try
            {
                var jns = MD5.ToMD5(mkcu.Trim());
                var acb = db.accs.Where(n => n.taikhoan == taikhoan && n.matkhau ==jns ).FirstOrDefault();
                //kiem tra mat khau cu 
                if (acb != null)
                {
                    acb.matkhau = MD5.ToMD5(Convert.ToString(mkmoi).Trim());
                    db.SaveChanges();
                    trave = "1";
                }
                else
                {
                    trave = "2";
                }
            }
            catch (Exception)
            {
                trave = "3";
            }
            return Json(trave);
        }
    }

}