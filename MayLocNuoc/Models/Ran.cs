using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MayLocNuoc.Models
{
    public class Ran
    {
        public int songaunhien()
        {
            Random ran = new Random();
            return ran.Next(1, 999999);
        }
    }
}