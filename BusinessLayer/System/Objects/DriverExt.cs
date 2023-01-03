using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    internal class DriverExt : DriverFuncs
    {
        private static DriverExt instance = null;
        public static DriverExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new DriverExt();
                return instance;
            }
        }
    }
}
