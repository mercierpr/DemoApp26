using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp26.AppData
{
    internal class AppData
    {
        public static demo26Entities1 db = new demo26Entities1 ();
        public static userss CurrentUser;
        public static bool IsAdmin = false;
        public static orders CurrentOrder;
        public static orders EditOrder;
        public static orders CurrentProduct;
        public static orders EditProduct;
    }
}
