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
    public partial class UIHomePage : System.Web.UI.Page
    {
        public List<POST> ls = new List<POST>();
        public List<Information> informations = new List<Information>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Trang chủ";
            LoadPOST();

            informations = HRFunctions.Instance.SelectAll();
        }

        private void LoadPOST()
        {
            ls = HRFunctions.Instance.Select_All_POST();
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