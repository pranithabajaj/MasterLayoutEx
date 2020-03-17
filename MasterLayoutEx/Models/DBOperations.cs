using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterLayoutEx.Models
{
    public class DBOperations
    {
        static DemoEntities1 D = new DemoEntities1();
        
        public static bool GetDetails(string uname,string pwd)
        {
            var V = from E in D.tbl_login
                    where E.username == uname && E.password == pwd
                    select E;
            if (V.ToList().Count == 1)
                return true;
            else
                return false;
        }
        
    }
}