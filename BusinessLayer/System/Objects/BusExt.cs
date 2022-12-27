using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusExt : BusFuncs
    {
        private static BusExt instance;

        public static BusExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new BusExt();
                return instance;
            }
        }
    }
}
