using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.System.Object
{
    public class StopRouteExt
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
