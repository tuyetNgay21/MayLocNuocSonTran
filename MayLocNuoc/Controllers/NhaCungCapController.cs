using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MayLocNuoc.Models;
using PagedList;

namespace MayLocNuoc.Controllers
{
    public class NhaCungCapController : Controller
    {
        mayLocNuocEntities db = new mayLocNuocEntities();
        // GET: NhaCungCap
        [HttpGet]
        public ActionResult Index(string tk, int page = 1, int size = 9)
        {
            int TL = Convert.ToInt32(tk);
            var model = db.sanphams.Where(m => m.idIfncc == TL).OrderBy(n => n.soluong).ToPagedList(page, size);
            return View(model);
        }
        public ActionResult TrangChu(int page = 1, int size = 9)
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("DN", "QuanTri");
            }
            else
            {
                var id = db.NhaCungCaps.Where(n => n.taikhoan == save.taikhoan).FirstOrDefault();
                int TL = Convert.ToInt32(id.idIfncc);
                var model = db.sanphams.Where(m => m.idIfncc == TL).OrderBy(n => n.soluong).ToPagedList(page, size);
                return View(model);
            }
        }

        public ActionResult Product_To()
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("DN", "QuanTri");
            }
            else
            {
                return View();
            }
        }
        public ActionResult ThemSanPham()
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("DN", "QuanTri");
            }
            else
            {
                return View();
            }

        }
        // doanh thu////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ActionResult xemDoanhthu()
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("DN", "QuanTri");
            }
            else
            {
                return View();
            }
        }
        //trong thang
        public ActionResult In_Month()
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("DN", "QuanTri");
            }
            else
            {
                return View();
            }
        }
        //san pham trong mot ngay trong thang

        public ActionResult Product_In_Day_inMonth(int? ngay, int? thang, int? nam)
        {
            int ngayhientai = Convert.ToInt32(DateTime.Now.Day);
            int Thanghientai = Convert.ToInt32(DateTime.Now.Month);
            int Namhientai = Convert.ToInt32(DateTime.Now.Year);
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("DN", "QuanTri");
            }
            else
            {
                if ( thang == null || nam == null)
                {
                    ViewBag.ngay = ngayhientai;
                    ViewBag.thang = Thanghientai;
                    ViewBag.nam = Namhientai;
                    return View();
                }
                else
                {
                    if (ngay == null)
                    {
                        ViewBag.ngay = ngayhientai;
                        ViewBag.thang = thang;
                        ViewBag.nam = nam;
                        return View();
                    }
                    else
                    {
                        ViewBag.ngay = ngay;
                        ViewBag.thang = thang;
                        ViewBag.nam = nam;
                        return View();
                    }
                }
                

            }
        }
        //đánh Giá Của Tất cả sản phẩm chuyển qua trang chi tiết
        public ActionResult Evaluate_Product()
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("DN", "QuanTri");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Product_not_to()
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("DN", "QuanTri");
            }
            else
            {
                return View();
            }
        }
        public ActionResult RepComment()
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("DN", "QuanTri");
            }
            else
            {
                return View();
            }
        }
        public ActionResult chưathem1()
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("DN", "QuanTri");
            }
            else
            {
                return View();
            }
        }
        public ActionResult chưathem2()
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("DN", "QuanTri");
            }
            else
            {
                return View();
            }
        }
        public ActionResult chưathem3()
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("DN", "QuanTri");
            }
            else
            {
                return View();
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

        public ActionResult SuaProduct(string ma)
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("DN", "QuanTri");
            }
            else
            {
                int ma1 = Convert.ToInt32(ma);
                var sanpham = db.sanphams.Where(n => n.idSP == ma1).FirstOrDefault();
                return View(sanpham);
            }
        }
        public ActionResult Info()
        {
            if (save.taikhoan == null || save.taikhoan == "")
            {
                return RedirectToAction("DN", "QuanTri");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        //sua san pham//////////////////////////////////////////////////////////////////////////////////////////////
        public JsonResult docsanpham(string MaSanPham)
        {
            int MaSanPham1 = Convert.ToInt32(MaSanPham.Trim());
            var sa = db.sanphams.Where(n => n.idSP == MaSanPham1).FirstOrDefault();
            var sb = db.NhaCungCaps.Where(m => m.idIfncc == sa.idIfncc).FirstOrDefault();
            if (sb.taikhoan == save.taikhoan)
            {

            }
            else
            {

            }
            var xyz = new string[sa.idSP];
            return Json(xyz);
        }
        //ket thuc sua san pham///////////////////////////////////////////////////////////////////////////////////
        //them san pham vao /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public JsonResult Add_product(string name_product,
                                      string length_product,
                                      string with_product,
                                      string height_product,
                                      string title_product,
                                      string number_product,
                                      string core_product,
                                      string producttion_product,
                                      string speed_product,
                                      string technology_product,
                                      string pump_product,
                                      string price_product,
                                      string brand_product,
                                      string quality_product,
                                      string where_production,
                                      string free_product,
                                      string number_free_product,
                                      string Imgchinh,
                                      string Img1,
                                      string Img2,
                                      string Img3,
                                      string Img4)
        {
            string trave = "";
            //tim kiem nha cung cap theo tai khoan hien co
            /*
             * 1 là tài khoản hiện tại rỗng
             * 2 là nha cung cấp chưa đăng ký
             * 3 là đã gặp vấn đề về dữ liệu
             * 4 laf hoàn thành
             */
            if (save.taikhoan == null || save.taikhoan == "")
            {
                trave = "1";
            }
            else
            {

                var manhacungcap = db.NhaCungCaps.Where(n => n.taikhoan == save.taikhoan).FirstOrDefault().idIfncc;
                if (manhacungcap == null)
                {
                    trave = "2";
                }
                else
                {
                    try
                    {
                        sanpham sp = new sanpham();
                        sp.tensp = name_product;
                        sp.dai = Convert.ToInt32(length_product);
                        sp.rong = Convert.ToInt32(with_product);
                        sp.cao = Convert.ToInt32(height_product);
                        sp.tieude = title_product;
                        sp.soluong = Convert.ToInt32(number_product);
                        sp.soLoiLoc = Convert.ToInt32(core_product);
                        sp.congxuat = producttion_product;
                        sp.tocdoloc = speed_product;
                        sp.congnghekhangkhuan = technology_product;
                        sp.congXuatBom = pump_product;
                        sp.gia = Convert.ToInt32(price_product);
                        sp.thuongHieu = brand_product;
                        sp.chatluong = quality_product;
                        sp.noisanxuat = where_production;
                        sp.magiamgia = free_product;
                        sp.sophantram = Convert.ToInt32(number_free_product);
                        sp.anhsanpham1 = Imgchinh;
                        sp.anhsanpham2 = Img1;
                        sp.anhsanpham3 = Img2;
                        sp.anhsanpham4 = Img3;
                        sp.anhsanpham5 = Img4;
                        sp.daxoa = false;
                        sp.hethang = false;
                        sp.idIfncc = manhacungcap;
                        sp.soluongdaban = 0;
                        db.sanphams.Add(sp);
                        db.SaveChanges();

                        var xyz = db.sanphams.Where(n => n.idIfncc == manhacungcap &&
                                               n.tensp == name_product &&
                                               n.anhsanpham2 == Img1 &&
                                               n.anhsanpham3 == Img2 &&
                                               n.anhsanpham4 == Img3 &&
                                               n.anhsanpham5 == Img4 &&
                                               n.anhsanpham1 == Imgchinh
                                           ).FirstOrDefault();
                        trave = "kd" + xyz.idSP;
                    }
                    catch (Exception)
                    {
                        trave = "3";
                    }
                }
            }
            return Json(trave);
        }

        public string Upadate_Img_Product(HttpPostedFileBase anh)
        {
            try
            {
                anh.SaveAs(Server.MapPath("~/Content/CONTM/IMG_Product/" + save.taikhoan + anh.FileName));
                string avc = "../Content/CONTM/IMG_Product/" + save.taikhoan + anh.FileName;
                return avc;
            }
            catch (Exception)
            {
                return "";
            }


        }
        //ket thuc them san pham /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //product_to su ly json //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public JsonResult daLapDat(string idcuano, string idsanpham)
        {
            /*
             * 1 co loi he thong  
             * 2 san pham nay khong phai cua ban 
             * 3 thanh cong
             */
            string trave = "";
            try
            {
                var iddamua = Convert.ToInt32(idcuano);
                var idsp = Convert.ToInt32(idsanpham);
                var idnhacungcap = db.sanphams.Where(n => n.idSP == idsp).FirstOrDefault();
                if (db.NhaCungCaps.Where(v => v.idIfncc == idnhacungcap.idIfncc).FirstOrDefault().taikhoan == save.taikhoan)
                {
                    var sanphamhientai = db.daMuas.Where(m => m.idDM == iddamua).FirstOrDefault();
                    sanphamhientai.dalapdat = DateTime.Now;
                    db.SaveChanges();
                    trave = "3";
                }
                else
                {
                    trave = "2";
                }
            }
            catch (Exception)
            {
                trave = "1";
            }
            return Json(trave);
        }

        public JsonResult dangVanChuyen(string idcuano, string idsanpham)
        {
            /*
            * 1 co loi he thong  
            * 2 san pham nay khong phai cua ban 
            * 3 thanh cong
            */
            string trave = "";
            try
            {
                var iddamua = Convert.ToInt32(idcuano);
                var idsp = Convert.ToInt32(idsanpham);
                var idnhacungcap = db.sanphams.Where(n => n.idSP == idsp).FirstOrDefault();
                if (db.NhaCungCaps.Where(v => v.idIfncc == idnhacungcap.idIfncc).FirstOrDefault().taikhoan == save.taikhoan)
                {
                    var sanphamhientai = db.daMuas.Where(m => m.idDM == iddamua).FirstOrDefault();
                    sanphamhientai.dangVanChuyen = true;
                    db.SaveChanges();
                    trave = "3";
                }
                else
                {
                    trave = "2";
                }
            }
            catch (Exception)
            {
                trave = "1";
            }
            return Json(trave);
        }
        public JsonResult thayDoiNgayLapDat(string idcuano, string idsanpham, string ngay, string thang, string nam)
        {
            /*
            * 1 co loi he thong  
            * 2 san pham nay khong phai cua ban 
            * 3 thanh cong
            */
            string trave = "";
            try
            {
                var iddamua = Convert.ToInt32(idcuano);
                var idsp = Convert.ToInt32(idsanpham);
                var idnhacungcap = db.sanphams.Where(n => n.idSP == idsp).FirstOrDefault();
                if (db.NhaCungCaps.Where(v => v.idIfncc == idnhacungcap.idIfncc).FirstOrDefault().taikhoan == save.taikhoan)
                {
                    var sanphamhientai = db.daMuas.Where(m => m.idDM == iddamua).FirstOrDefault();
                    sanphamhientai.ngayLapDat = new DateTime(Convert.ToInt32(nam), Convert.ToInt32(thang), Convert.ToInt32(ngay));
                    db.SaveChanges();
                    trave = "3";

                }
                else
                {
                    trave = "2";
                }
            }
            catch (Exception)
            {
                trave = "1";
            }
            return Json(trave);
        }
    }
}