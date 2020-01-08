using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MayLocNuoc.Models
{
    public static class KyTu
    {
        public static bool kiemtra(string a)
        {
            if(a.Contains("<")==true || a.Contains("&") == true || a.Contains(">") == true ||
                a.Contains("%") == true || a.Contains(";") == true || 
                a.Contains("}") == true || a.Contains("{") == true || a.Contains("]") == true || 
                a.Contains("[") == true || a.Contains("?") == true )
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}