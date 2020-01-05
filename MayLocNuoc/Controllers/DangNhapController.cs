using MayLocNuoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MayLocNuoc.Controllers
{
    public class DangNhapController : Controller
    {
        mayLocNuocEntities db = new mayLocNuocEntities();
        // GET: DangNhap
        public ActionResult Log()
        {

            return View();
        }
        public ActionResult registration()
        {

            return View();
        }
        public ActionResult registGetPasswordration()
        {

            return View();
        }
        public ActionResult changePassword()
        {

            return View();
        }
        [HttpPost]
        public JsonResult themtaikhoan(string a, string b, string c, string d, string e, string g)
        {
            string avg = "";
            if (KyTu.kiemtra(a) == true || KyTu.kiemtra(b) == true || KyTu.kiemtra(c) == true || KyTu.kiemtra(d) == true || KyTu.kiemtra(e) == true)
            {
                avg = "Không được nhập Ký tự đặc biệt chỉ có thể nhập a-z 0-9";
            }
            else
            {

                //tim so dien thoai
                try
                {
                    if (db.infoes.Where(n => n.number_phone == a).Count() != 0)
                    {
                        avg = "Số điện thoại đã được sử dụng";
                    }
                    else
                    {
                        if (db.accs.Where(n => n.taikhoan == a).Count() != 0)
                        {
                            avg = "sdt đã có tài khoản đăng ký";
                        }
                        else
                        {
                            try
                            {
                                acc ac = new acc();
                                ac.taikhoan = a;
                                ac.matkhau = MD5.ToMD5(b.Trim());
                                ac.daxoa = false;
                                ac.email = g;
                                ac.chucvu = 3;
                                ac.taikhoanquanly = "ADminVip";

                                info inf = new info();
                                inf.nameFull = d;
                                inf.age = Convert.ToInt32(e.Trim());
                                inf.adress = c;
                                inf.number_phone = a;
                                inf.taikhoan = a;

                                db.accs.Add(ac);
                                db.infoes.Add(inf);
                                db.SaveChanges();
                                avg = "Cảm Ơn Bạn Đã sử dụng dịch vụ của chúng tôi";
                            }
                            catch (Exception)
                            {

                                avg = "đã có lỗi sảy ra ";
                            }

                        }
                    }
                }
                catch
                {
                    avg = "404";
                }


            }

            return Json(avg);
        }
        public JsonResult dangnhap1123(string a, string b)
        {

            string trave = "";
            string avc = MD5.ToMD5(b.Trim());
            int c = db.accs.Where(n => n.taikhoan == a && n.matkhau == avc).Count();
            if (c == 1)
            {
                trave = a;
                save.nhap(trave);
            }
            else
            {
                trave = c.ToString();
            }
            return Json(trave);
        }

    }
}