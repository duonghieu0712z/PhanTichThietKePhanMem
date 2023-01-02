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
    public partial class NoiDung : System.Web.UI.Page
    {
        public Information information = new Information();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(Request.QueryString["id"]);
                information = DocumentManagement.Instance.infomationFunc.Info_Select_ID(ID);
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Trang này không có nội dung. Vui lòng quay lại.')", true);
            }
        }
    }
}