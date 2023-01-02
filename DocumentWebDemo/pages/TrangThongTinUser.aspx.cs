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
    public partial class TrangThongTinUser : System.Web.UI.Page
    {
        public List<Information> informations = new List<Information>();
        protected void Page_Load(object sender, EventArgs e)
        {
            informations = DocumentManagement.Instance.infomationFunc.Information_Select_All();
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            informations = DocumentManagement.Instance.infomationFunc.Info_Select_By("Title",txtFind.Text.Trim());
            if (txtFind.Text == "")
            {
                informations = DocumentManagement.Instance.infomationFunc.Information_Select_All();
            }
        }
    }
}