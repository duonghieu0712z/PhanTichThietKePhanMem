using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.DBAccess;
using BusinessLayer.Functions;

namespace Web.Pages
{
    public partial class XuLyViPhamHome : System.Web.UI.Page
    {
        public List<HandlingViolation> ls = new List<HandlingViolation>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ls = HRFunctions.Instance.SelectAllHand();
        }
    }
}