using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.DBAccess;
using BusinessLayer.Functions;

namespace Web.Pages
{
    public partial class StopRoutePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Refresh();
            }
            //Page.Title = "Quản lý lộ trình - điểm dừng";
        }
        private void Refresh()
        {
            GridViewStopRoute.DataSource = HRFunctions.Instance.SelectAllStopRoute();
            GridViewStopRoute.DataBind();
        }
        private void ClearText()
        {
            this.StopRouteIDStopRoute.Text = String.Empty;
            this.StopRouteIDRoute.Text = String.Empty;
            this.StopRouteIDStoping.Text = String.Empty;
            this.StopRouteOrder.Text = String.Empty;
        }
        private Stop_Route GetStopRouteFromRow(int index)
        {
            var row = GridViewStopRoute.Rows[index];
            //TestPlace.Text += DateTime.Parse(row.Cells[8].Text);
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
            onTestGetStopRoute();
            Refresh();
            ClearText();
        }
        private void onTestGetStopRoute()
        {
            Stop_Route sr = GetStopRoute();
            TestPlace.Text = $"ID: {sr.StopRouteID}\n" +
                $"IDRoute: {sr.RouteID}\n" +
                $"IDEndPosition: {sr.EndPositionID}\n" +
                $"Order: {sr.Order}";

        }
        private Stop_Route GetStopRoute()
        {
            Stop_Route stopRoute = new Stop_Route();
            int StopRouteID = 0;
            int RouteID=0;
            int EndPositionID=0;
            int Order= 0;
               
            int.TryParse(this.StopRouteIDStopRoute.Text, out StopRouteID);
            int.TryParse(this.StopRouteIDRoute.Text, out RouteID);
            int.TryParse(this.StopRouteIDStoping.Text, out EndPositionID);
            int.TryParse(this.StopRouteOrder.Text, out Order);

            stopRoute.StopRouteID = StopRouteID;
            stopRoute.RouteID = RouteID;
            stopRoute.EndPositionID = EndPositionID;
            stopRoute.Order = Order;

            return stopRoute;
        }
        private void SetStopRouteData(Stop_Route sr)
        {
            this.StopRouteIDStopRoute.Text = sr.StopRouteID.ToString();
            this.StopRouteIDRoute.Text = sr.RouteID.ToString();
            this.StopRouteIDStoping.Text = sr.EndPositionID.ToString();
            this.StopRouteOrder.Text = sr.Order.ToString();
        }

        protected void GridViewStopRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stop_Route sr = GetStopRouteFromRow(GridViewStopRoute.SelectedIndex);
            SetStopRouteData(sr);
        }

        protected void ButtonDeleteStopRoute_Click(object sender, EventArgs e)
        {
            int.TryParse(this.StopRouteIDStopRoute.Text, out var id);
            HRFunctions.Instance.DeleteStopRoute(id);
            Refresh();
            ClearText();
        }

        protected void ButtonUpdateStopRoute_Click(object sender, EventArgs e)
        {
            Stop_Route sr = GetStopRoute();
            HRFunctions.Instance.InsertNUpdateStopRoute(sr);
            onTestGetStopRoute();
            Refresh();
        }
    }
}