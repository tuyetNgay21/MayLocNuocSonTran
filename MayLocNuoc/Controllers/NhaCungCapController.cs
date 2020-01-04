using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MayLocNuoc.Models;

namespace MayLocNuoc.Controllers
{
    public class NhaCungCapController : Controller
    {
        mayLocNuocEntitiesNhaCungCap db = new mayLocNuocEntitiesNhaCungCap();
        // GET: NhaCungCap
        [HttpGet]
        public ActionResult TrangChu()
        {
            return View();
        }
        public ActionResult ThemSanPham()
        {
            return View();
        }
        public ActionResult xemDoanhthu()
        {
            return View();
        }
        public ActionResult SuaProduct()
        {
            return View();
        }
        public ActionResult ChinhSuaSanPham()
        {
            return View();
        }
        public ActionResult xemNCC()
        {
            return View();
        }
        public ActionResult Info()
        {
            return View();
        }
        public ActionResult RepComment()
        {
            return View();
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
             */
            if (save.taikhoan == null || save.taikhoan == "")
            {
                trave = "1";
            }
            else
            {
                var manhacungcap = db.infoes.Where(n => n.taikhoan == save.taikhoan).FirstOrDefault().idIf;
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
                        sp.gia =Convert.ToInt32( price_product);
                        sp.thuongHieu = brand_product;
                        sp.chatluong = quality_product;
                        sp.noisanxuat = where_production;
                        sp.magiamgia= free_product;
                        sp.sophantram= Convert.ToInt32(number_free_product);
                        sp.anhsanpham1 = Imgchinh;
                        sp.anhsanpham2 = Img1;
                        sp.anhsanpham3 = Img2;
                        sp.anhsanpham4 = Img3;
                        sp.anhsanpham5 = Img4;

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
            anh.SaveAs(Server.MapPath("~/Content/CONTM/IMG_Product/" + save.taikhoan + anh.FileName));
            string avc = "../Content/CONTM/IMG_Product/" + save.taikhoan + anh.FileName;
            return avc;
        }
        //ket thuc them san pham /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}