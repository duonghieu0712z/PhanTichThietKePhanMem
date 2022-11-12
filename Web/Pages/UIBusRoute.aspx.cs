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
    public partial class UIBusRoute : System.Web.UI.Page
    {
        public List<BusRoute> ls = new List<BusRoute>();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadBusRoute();
            Page.Title = "Tuyến";
        }
        private void LoadBusRoute()
        {
            ls = HRFunctions.Instance.SelectAllBusRoute();
        }

        private void LoadTimKiem()
        {
            this.ls = HRFunctions.Instance.FindBusRoute(this.txtSearch.Value);
            if (ls == null || ls.Count == 0)
            {
                this.Label1.Text = "Không tìm thấy dữ liệu.";
            }
        }

        protected void btnRouView_Click(object sender, EventArgs e)
        {
            LoadTimKiem();
        }
    }
}