using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusTypeExt : BusTypeFuncs
    {
        private static BusTypeExt instance;

        public static BusTypeExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new BusTypeExt();
                return instance;
            }
        }
    }
}
