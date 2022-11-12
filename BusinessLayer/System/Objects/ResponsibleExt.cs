using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ResponsibleExt : ResponsibleFuncs
    {
        private static ResponsibleExt instance = null;
        public static ResponsibleExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new ResponsibleExt();
                return instance;
            }
        }
    }
}
