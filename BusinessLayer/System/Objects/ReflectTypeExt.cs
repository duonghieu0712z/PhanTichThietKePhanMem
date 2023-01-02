using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ReflectTypeExt : ReflectTypeFuncs
    {
        private static ReflectTypeExt instance = null;
        public static ReflectTypeExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new ReflectTypeExt();
                return instance;
            }
        }


    }
}
