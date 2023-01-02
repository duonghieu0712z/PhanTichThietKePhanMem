using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ReflectExt : ReflectFuncs
    {
        private static ReflectExt instance = null;
        public static ReflectExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new ReflectExt();
                return instance;
            }
        }
    }
}
