using BusinessLayer.Functions;
using System;
using System.Web.UI;

namespace Web.Pages
{
    public partial class UISearchRoute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Tra cứu thông tin lộ trình";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindingRouteData();
            this.GridViewSearchRoute.Visible = true;
            this.lblRoute.Visible = true;
        }
        private void BindingRouteData()
        {
            this.GridViewSearchRoute.DataSource = HRFunctions.Instance.SelectAllRoute();
            this.GridViewSearchRoute.DataBind();

        }

        protected void GridViewSearchRoute_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
        }


        private void BindingBusStopData()
        {
            this.GridViewSearchBusStop.DataSource = HRFunctions.Instance.SelectAllBusStop();
            this.GridViewSearchBusStop.DataBind();
        }

        protected void GridViewSearchRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingBusStopData();
            this.GridViewSearchBusStop.Visible = true;
            this.lblBusStop.Visible = true;
        }

        protected void GridViewSearchBusStop_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
        }
    }
}