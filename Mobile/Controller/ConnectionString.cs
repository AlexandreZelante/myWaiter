using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myWaiter.Mobile.Controller
{
    public static class ConnectionString
    {
        public static string getConString()
        {
            return "Data Source=ZZ-HP;Initial Catalog=DB_MyWaiter;Integrated Security=true";
        }
    }
}