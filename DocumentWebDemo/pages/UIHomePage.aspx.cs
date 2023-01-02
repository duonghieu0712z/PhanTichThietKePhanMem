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
    public partial class UIHomePage : System.Web.UI.Page
    {
        public List<POST> ls = new List<POST>();
        public List<Information> informations = new List<Information>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Trang chủ";
            LoadPOST();

            informations = DocumentManagement.Instance.infomationFunc.Information_Select_All();
        }

        private void LoadPOST()
        {
            ls = DocumentManagement.Instance.postFunc.POST_Select_All();
        }

        //protected void btnFind_Click(object sender, EventArgs e)
        //{
        //    informations = HRFunctions.Instance.SearchByName(txtFind.Text.Trim());
        //    if (txtFind.Text == "")
        //    {
        //        informations = HRFunctions.Instance.SelectAll();
        //    }
        //}
    }
}