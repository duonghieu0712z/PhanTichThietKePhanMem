using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentLayer.MasterSystem;
using DocumentLayer;

namespace DocumentWebDemo.pages
{
    public partial class HomeXuLyViPham : System.Web.UI.Page
    {
        public List<HandlingViolation> ls = new List<HandlingViolation>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ls = DocumentManagement.Instance.handlingViolations.HandlingViolation_Select_All();
        }

    }

}