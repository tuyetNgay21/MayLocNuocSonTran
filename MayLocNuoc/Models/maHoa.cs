using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MayLocNuoc.Models
{
    public class maHoa
    {
        public static string mahoa(string a)
        {
            string bc = "";
            var d = a.ToCharArray();
            for (int i = 0; i < a.ToCharArray().Length; i++)
            {

                var az = ((int)a.ToCharArray()[i] + i * 1 + i * i - 5 * i + 1507);


                bc += (char)az;
            }

            return bc;
        }


        public static string Giaimahoa(string a)
        {
            string bc = "";
            var d = a.ToCharArray();
            for (int i = 0; i < a.ToCharArray().Length; i++)
            {

                var az = ((int)a.ToCharArray()[i] - i * 1 - i * i + 5 * i - 1507);


                bc += (char)az;
            }

            return bc;
        }
    }
}