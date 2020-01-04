using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace MayLocNuoc.Models
{
    public class guiMail
    {
        public bool ToguiMail(string name, string noidung)
        {
            string senderID = "hainam1507x@gmail.com";
            string senderPassword = "hainam9xtb";
            bool result = false;

            string body = "Đây Là Mật Khẩu Mới Của Bạn " + noidung + "  Bạn Nên đổi Mật Khẩu";
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(name);
                mail.From = new MailAddress(senderID);
                mail.Subject = "Máy Lọc Nước Sơn Trần - Lấy lại Mật Khẩu";
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential(senderID, senderPassword);
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);
                result = true;
            }
            catch (Exception )
            {
                result = false; 
            }
            return result;
        }
    }
}