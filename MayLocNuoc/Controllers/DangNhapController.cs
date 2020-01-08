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
        public JsonResult LogJson(string taikhoan, string matkhau)
        {
            /*
             * -1 là có lỗi xảy ra
             * 0 la tai khoan khong chinh xac
             * 1 là mạt khẩu không chính xác
             * đăng nhập thành công xác định là admin hay người dùng
             * 2 là người dùng 
             * 3 là loại khonmg cho đăng nhập trang này 
             */
            string trave = "";
            try
            {


                int c = db.accs.Where(n => n.taikhoan == taikhoan).Count();
                if (c == 1)
                {
                    string avc = MD5.ToMD5(matkhau.Trim());
                    int m = db.accs.Where(n => n.matkhau == avc && n.taikhoan == taikhoan).Count();
                    if (m == 1)
                    {
                        var k = db.accs.Where(n => n.taikhoan == taikhoan && n.matkhau == avc).FirstOrDefault();
                        if (k.chucvu == 3)
                        {
                            //luu cookie
                            save.taikhoan = taikhoan.Trim();
                            HttpCookie ck = new HttpCookie("Máy Lọc Nước Sơn Trần");
                            ck.Value = maHoa.mahoa(taikhoan + "1507" + MD5.ToMD5(matkhau.Trim()));
                            ck.Expires = DateTime.Now.AddDays(15);
                            Response.Cookies.Add(ck);
                            //luu section 
                            trave = "2";//trave roi chuyen trang
                        }
                        else
                        {
                            trave = "3";
                        }
                    }
                    else
                    {
                        trave = "1";
                    }
                }
                else
                {
                    trave = "0";
                }
            }
            catch (Exception)
            {

                trave = "-1";
            }
            return Json(trave);
        }
        public JsonResult registGetPasswordrationJson(string AccdanhNhap_Email, string EmailLayPass)
        {
            /*
             * 1 la tai khoan khong chinh xac
             * 2 la gmail khong chinh xac 
             * 3 la thanh cong 
             * 0 la he thong gap loi
             */
            string Trave = "";
            try
            {
                if (db.accs.Where(n => n.taikhoan == AccdanhNhap_Email).Count() == 1)
                {
                    if (db.accs.Where(n => n.taikhoan == AccdanhNhap_Email && n.email == EmailLayPass).Count() == 1)
                    {
                        guiMail gm = new guiMail();
                        Ran r = new Ran();
                        if (gm.ToguiMail(EmailLayPass, r.songaunhien().ToString()) == true)
                        {
                            Trave = "3";
                        }
                        else
                        {
                            Trave = "0";
                        }
                    }
                    else
                    {
                        Trave = "2";
                    }
                }
                else
                {
                    Trave = "1";
                }
            }
            catch (Exception)
            {

                Trave = "0";
            }
            return Json(Trave);
        }
        //changPass
        public JsonResult changePasswordJson(string taikhoanthaydoi, string passOld, string passNew)
        {
            /*
             * 1 trong co ky tu dac biet
             * 2 hệ thống gặp lỗi 
             * 3 tai khoan khong chinh xac
             * 4 mat khau khong chinh xac
             * 5 mat khau da duowc thay doi
             */
            string avg = "";
            try
            {
                if (KyTu.kiemtra(taikhoanthaydoi) == true || KyTu.kiemtra(passOld) == true || KyTu.kiemtra(passNew) == true)
                {
                    avg = "1";
                }
                else
                {
                    if (db.accs.Where(n => n.taikhoan == taikhoanthaydoi).Count() == 1)
                    {
                        var mkOld = MD5.ToMD5(passOld.Trim());
                        if (db.accs.Where(n => n.taikhoan == taikhoanthaydoi && n.matkhau == mkOld).Count() == 1)
                        {
                            var ChangPassss = db.accs.Where(n => n.taikhoan == taikhoanthaydoi && n.matkhau == mkOld).FirstOrDefault();

                            ChangPassss.matkhau = MD5.ToMD5(passNew.Trim());

                            db.SaveChanges();
                            avg = "5";
                        }
                        else
                        {
                            avg = "4";
                        }
                    }
                    else
                    {
                        avg = "3";
                    }
                }
            }
            catch (Exception)
            {

                avg = "2";
            }


            return Json(avg);
        }

        //add product in database
        //changPass
        public JsonResult RegistrationJson(string AccRegistration, string PassRegistration,
                string NameRegistration, string numberPhoneRegistration,
               string AdressRegistration, string EmailRegistration)
        {
            /*
             * 1 trong co ky tu dac biet
             * 2 kiem tra nay tai khoan da co chuwa 
             * 3 kiem tra xem da co gmail nay chua
             * 4 co loi he thong
             * 5  thanh cong 
             */
            string Trave = "";
            try
            {
                if (AccRegistration==null || AccRegistration==""||
                    PassRegistration == null || PassRegistration == "" ||
                    NameRegistration == null || NameRegistration == "" ||
                    numberPhoneRegistration == null || numberPhoneRegistration == "" ||
                    AdressRegistration == null || AdressRegistration == "" ||
                    EmailRegistration == null || EmailRegistration == "" )
                {
                    Trave = "6";
                }
                else
                {
                    if (KyTu.kiemtra(AccRegistration) == true || KyTu.kiemtra(PassRegistration) == true ||
                                        KyTu.kiemtra(NameRegistration) == true || KyTu.kiemtra(numberPhoneRegistration) == true ||
                                        KyTu.kiemtra(AdressRegistration) == true || KyTu.kiemtra(EmailRegistration) == true)
                    {
                        Trave = "1";
                    }
                    else
                    {
                        if (db.accs.Where(n => n.taikhoan == AccRegistration).Count() == 0)
                        {
                            if (db.accs.Where(n => n.email == EmailRegistration).Count() == 0)
                            {
                                acc ac = new acc();
                                ac.taikhoan = AccRegistration;
                                ac.matkhau = MD5.ToMD5(PassRegistration.Trim());
                                ac.daxoa = false;
                                ac.email = EmailRegistration;
                                ac.chucvu = 3;
                                ac.taikhoanquanly = "ADminVip";

                                info inf = new info();
                                inf.nameFull = NameRegistration;
                                inf.age = Convert.ToInt32(18);
                                inf.adress = AdressRegistration;
                                inf.number_phone = numberPhoneRegistration;
                                inf.taikhoan = AccRegistration;

                                db.accs.Add(ac);
                                db.infoes.Add(inf);
                                db.SaveChanges();

                                Trave = "5";
                            }
                            else
                            {
                                Trave = "3";
                            }
                        }
                        else
                        {
                            Trave = "2";
                        }
                    }
                }
                
            }
            catch (Exception)
            {

                Trave = "4";
            }


            return Json(Trave);
        }
    }
}