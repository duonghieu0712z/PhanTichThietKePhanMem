using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PostExt : PostFuncs
    {
        private static PostExt instance = null;
        public static PostExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new PostExt();
                return instance;
            }
        }
    }
}
