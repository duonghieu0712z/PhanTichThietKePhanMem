using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RouteExt : RouteFuncs
    {
        private static RouteExt instance = null;
        public static RouteExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new RouteExt();
                return instance;
            }
        }

        public List<Route> SearchByPosition(int idStart, int idEnd)
        {
            using (var db = GetContext())
            {
                string sql = "";
                var ls = db.Routes.SqlQuery(sql);
                if (ls != null && ls.Any()) return ls.ToList<Route>();
                return new List<Route>();
            }
        }
    }
}
