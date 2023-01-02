using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DocumentExt : DocumentFunc
    {
        private static DocumentExt instance = null;
        public static DocumentExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new DocumentExt();
                return instance;
            }
        }
    }
}
