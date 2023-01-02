using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class InformationExt : InformationFunctions
    {
        private static InformationExt instance = null;
        public static InformationExt Instance
        {
            get {
                if (instance == null)
                instance = new InformationExt();
                return instance; 
            }
        }
    }
}
