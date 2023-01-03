using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusRouteExt : BusRouteFuncs
    {
        private static BusRouteExt instance = null;
        public static BusRouteExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new BusRouteExt();
                return instance;
            }
        }
    }
}
