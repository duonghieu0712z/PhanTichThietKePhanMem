using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentLayer;
using DocumentLayer.MasterSystem;
namespace DocumentWebDemo.pages
{
    public partial class UIDetailPost : System.Web.UI.Page
    {
        public POST ls = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);
                ls = DocumentManagement.Instance.postFunc.POST_Select_ID(id);
            }
            catch { Response.Redirect("/Pages/UIHomePage"); };
        }
    }
}