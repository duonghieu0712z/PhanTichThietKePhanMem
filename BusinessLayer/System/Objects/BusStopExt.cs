using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusStopExt : BusStopFuncs
    {
        private static BusStopExt instance = null;
        public static BusStopExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new BusStopExt();
                return instance;
            }
        }
    }
}
