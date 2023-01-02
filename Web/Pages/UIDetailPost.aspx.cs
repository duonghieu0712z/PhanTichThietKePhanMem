using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Pages
{
    public partial class UIDetailPost : System.Web.UI.Page
    {
        public POST ls = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);
                ls = HRFunctions.Instance.Select_POST_ID(id);
            }
            catch { Response.Redirect("/Pages/UIHomePage"); };
        }
    }
}