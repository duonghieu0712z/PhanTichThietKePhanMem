using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using System;
using System.Collections.Generic;

namespace Web.Pages
{
    public partial class StopRoutePage : System.Web.UI.Page
    {
        public List<Stop_Route> stop_Routes = new List<Stop_Route>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Refresh();
            }
        }
        private void Refresh()
        {
            GridViewStopRoute.DataSource = HRFunctions.Instance.SelectAllStopRoute();
            GridViewStopRoute.DataBind();
            stop_Routes = HRFunctions.Instance.SelectAllStopRoute();
            BindingDLRouteID();
            BindingDLEndPositionID();
        }

        private void BindingDLRouteID()
        {
            this.dlRouteID.DataSource = HRFunctions.Instance.SelectAllStopRoute();
            this.dlRouteID.DataValueField = "RouteID";
            this.dlRouteID.DataTextField = "RouteID";
            this.dlRouteID.DataBind();
        }

        private void BindingDLEndPositionID()
        {
            this.dlEndPositionID.DataSource = HRFunctions.Instance.SelectAllStopRoute();
            this.dlEndPositionID.DataValueField = "EndPositionID";
            this.dlEndPositionID.DataTextField = "EndPositionID";
            this.dlEndPositionID.DataBind();
        }

        private void ClearText()
        {
            this.IDStopRoute.Text = String.Empty;
            this.dlRouteID.Text = String.Empty;
            this.dlEndPositionID.Text = String.Empty;
            this.Order.Text = String.Empty;
        }
        private Stop_Route GetStopRouteFromRow(int index)
        {
            var row = GridViewStopRoute.Rows[index];
            return new Stop_Route()
            {
                StopRouteID = int.Parse(row.Cells[1].Text),
                RouteID = int.Parse(row.Cells[2].Text),
                EndPositionID = int.Parse(row.Cells[3].Text),
                Order = int.Parse(row.Cells[4].Text),
            };
        }

        protected void ButtonAddStopRoute_Click(object sender, EventArgs e)
        {
            Stop_Route sr = GetStopRoute();
            HRFunctions.Instance.InsertNUpdateStopRoute(sr);
            Refresh();
            ClearText();
        }
        private Stop_Route GetStopRoute()
        {
            Stop_Route stopRoute = new Stop_Route();
            int StopRouteID = 0;
            int RouteID = 0;
            int EndPositionID = 0;
            int Order = 0;

            StopRouteID = int.Parse(this.IDStopRoute.Text);
            RouteID = int.Parse(this.dlRouteID.SelectedValue);
            EndPositionID = int.Parse(this.dlEndPositionID.SelectedValue);
            Order = int.Parse(this.Order.Text);

            stopRoute.StopRouteID = StopRouteID;
            stopRoute.RouteID = RouteID;
            stopRoute.EndPositionID = EndPositionID;
            stopRoute.Order = Order;

            return stopRoute;
        }
        private void SetStopRouteData(Stop_Route sr)
        {
            this.IDStopRoute.Text = sr.StopRouteID.ToString();
            this.dlRouteID.SelectedValue = sr.RouteID.ToString();
            this.dlEndPositionID.SelectedValue = sr.EndPositionID.ToString();
            this.Order.Text = sr.Order.ToString();
        }

        protected void GridViewStopRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stop_Route sr = GetStopRouteFromRow(GridViewStopRoute.SelectedIndex);
            SetStopRouteData(sr);
        }

        protected void ButtonDeleteStopRoute_Click(object sender, EventArgs e)
        {
            int.TryParse(this.IDStopRoute.Text, out var id);
            HRFunctions.Instance.DeleteStopRoute(id);
            Refresh();
            ClearText();
        }

        protected void ButtonUpdateStopRoute_Click(object sender, EventArgs e)
        {
            Stop_Route sr = GetStopRoute();
            HRFunctions.Instance.InsertNUpdateStopRoute(sr);
            Refresh();
        }
    }
}
