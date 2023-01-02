using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class handlingViolationsExt : handlingViolations
    {
        private static handlingViolationsExt instance = null;

        public static handlingViolationsExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new handlingViolationsExt();
                return instance;
            }
        }
    }
}
