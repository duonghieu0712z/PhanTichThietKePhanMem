using BusinessLayer;
using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace QuanlyThongtin.Pages
{
    public partial class TrangThongTinUser : System.Web.UI.Page
    {
        public List<Information> informations = new List<Information>();
        protected void Page_Load(object sender, EventArgs e)
        {
            informations = HRFunctions.Instance.SelectAll();
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            informations = HRFunctions.Instance.SearchByName(txtFind.Text.Trim());
            if (txtFind.Text == "")
            {
                informations = HRFunctions.Instance.SelectAll();
            }
        }
    }
}
