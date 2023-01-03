using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    internal class DriverOfBusExt : DriverOfBusFuncs
    {
        private static DriverOfBusExt instance = null;
        public static DriverOfBusExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new DriverOfBusExt();
                return instance;
            }
        }
    }
}
