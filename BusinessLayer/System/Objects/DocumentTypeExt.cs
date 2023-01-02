using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DocumentTypeExt : DocumentTypeFunc
    {
        private static DocumentTypeExt instance = null;
        public static DocumentTypeExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new DocumentTypeExt();
                return instance;
            }
        }
    }
}
