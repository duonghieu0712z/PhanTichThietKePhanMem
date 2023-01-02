using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentLayer.BaseObjectMethods;
using DocumentLayer.MasterSystem;

namespace DocumentLayer.MasterSystem
{
    public class BaseSystemMethod
    {
        public DocumentFunc documentFunc = new DocumentFunc();
        public DocumentTypeFunc typeFunc = new DocumentTypeFunc();
        public IntroduceFunc introduce = new IntroduceFunc();
        public handlingViolations handlingViolations = new handlingViolations();
        public InfomationFunc infomationFunc = new InfomationFunc();
        public PostFunc postFunc = new PostFunc();
        public ReflectFunc reflectFunc = new ReflectFunc();
        public ReflectTypeFunc reflectTypeFunc = new ReflectTypeFunc();
    }
}
