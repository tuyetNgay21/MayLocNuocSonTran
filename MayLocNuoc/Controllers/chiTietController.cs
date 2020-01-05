using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MayLocNuoc.Models;

namespace MayLocNuoc.Controllers
{

    public class chiTietController : Controller
    {
        mayLocNuocEntities db = new mayLocNuocEntities();
        // GET: chiTiet
        public static int  idcuasanpham;
        [HttpGet]
        public ActionResult Index(int? id)
        {

            idcuasanpham = Convert.ToInt32(id);
           int  sanpham1 = db.F_laySanPham(id).Count();
            if (idcuasanpham ==0 || sanpham1==0)
            {
                return RedirectToAction("Error","Error1");
            }
            else
            {
                F_laySanPham_Result sanpham = new F_laySanPham_Result();
                sanpham = db.F_laySanPham(id).FirstOrDefault();
                ViewBag.sanpham = sanpham;
                List<F_laydanhdia_Result> danhGia;
                danhGia = db.F_laydanhdia(id).ToList();
                ViewBag.danhgia = danhGia;
                if (save.taikhoan == "" || save.taikhoan == null)
                {
                    ViewBag.taikhoan = "Chưa Đăng Nhập";
                }
                else
                {
                    ViewBag.taikhoan = save.taikhoan;
                    
                }
            }
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

        public JsonResult themDanhGia(string a, string b)
        {
           
            string trave = "";
            if(save.taikhoan==null|| save.taikhoan=="")
            {
                trave = "Bạn Cần đăng Nhập";
            }
            else
            {
                try
                {
                    danhgia dg = new danhgia();
                    dg.noidung = a;
                    dg.idSP = idcuasanpham;
                    dg.sosao = Convert.ToInt32(b.Trim());
                    dg.daxoa = false;
                    dg.solike = 0;
                    dg.taikhoan = save.taikhoan;
                    
                    db.danhgias.Add(dg);
                    db.SaveChanges();

                    trave = "1";
                }
                catch (Exception)
                {

                    trave = "Có Lỗi Rồi ";
                }
            }
            return Json(trave);
        }


        public JsonResult themlikedg(string a)
        {
            string trave = "";
            if (save.taikhoan==null ||save.taikhoan=="")
            {
                trave = "-1";
            }
            else
            {
                int xyz = Convert.ToInt32(a);
                if (db.liKedgs.Where(n => n.taikhoan == save.taikhoan && n.idDG == xyz).Count() >= 1)
                {
                    trave = "0";
                }
                else
                {
                    try
                    {
                        var solike = db.danhgias.Where(n => n.idDG == xyz).FirstOrDefault();
                        solike.solike = solike.solike + 1;
                        var taikhoanlike = new liKedg();
                        taikhoanlike.daxoa = false;
                        taikhoanlike.taikhoan = save.taikhoan;
                        taikhoanlike.idDG = xyz;
                        db.liKedgs.Add(taikhoanlike);
                        db.SaveChanges();
                        trave = "1";
                    }
                    catch (Exception)
                    {

                        trave = "-2";
                    }

                }
            }
            return Json(trave);
        }

        public JsonResult themcommentdg(string a , string b)
        {
            string trave = "";
            if (save.taikhoan == null || save.taikhoan == "")
            {
                trave = "-1";
            }
            else
            {
                int xyz = Convert.ToInt32(a);
                    try
                    {
                    comment con = new comment();
                    con.noidung = b;
                    con.idDG = xyz;
                    con.daxoa = false;
                    con.taikhoan = save.taikhoan;
                    con.solike = 0;
                    db.comments.Add(con);
                    db.SaveChanges();

                        trave = "1";
                    }
                    catch (Exception)
                    {

                        trave = "-2";
                    }
            }
            return Json(trave);
        }
    }
}