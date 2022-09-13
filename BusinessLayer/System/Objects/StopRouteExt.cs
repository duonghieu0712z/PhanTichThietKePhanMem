using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StopRouteExt : StopRouteFuncs
    {
        private static StopRouteExt instance = null;
        public static StopRouteExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new StopRouteExt();
                return instance;
            }
        }
    }
}
