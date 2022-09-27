using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.WebControls;

namespace Web.Pages
{
    public partial class StopRoutePage : System.Web.UI.Page
    {
        public List<Stop_Route> stop_Routes = new List<Stop_Route>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Quản lý lộ trình - điểm dừng";
            if (!IsPostBack)
            {
                Refresh();
            }
        }
        private void Refresh()
        {
            //GridViewStopRoute.DataSource = HRFunctions.Instance.SelectAllStopRoute();
            GridViewStopRoute.DataSource = HRFunctions.Instance.GetAllStopRouteInfo();
            GridViewStopRoute.DataBind();
            stop_Routes = HRFunctions.Instance.SelectAllStopRoute();
            BindingDLRouteID();
            BindingDLEndPositionID();
        }

        private void BindingDLRouteID()
        {
            this.dlRouteID.DataSource = HRFunctions.Instance.SelectAllRoute();
            this.dlRouteID.DataValueField = "RouteID";
            this.dlRouteID.DataTextField = "RouteName";
            this.dlRouteID.DataBind();
        }

        private void BindingDLEndPositionID()
        {
            this.dlEndPositionID.DataSource = HRFunctions.Instance.SelectAllBusStop();
            this.dlEndPositionID.DataValueField = "BusStopID";
            this.dlEndPositionID.DataTextField = "BusStopName";
            this.dlEndPositionID.DataBind();
        }

        private void ClearText()
        {
            try
            {
                this.IDStopRoute.Text = String.Empty;
                this.dlRouteID.Text = String.Empty;
                this.dlEndPositionID.Text = String.Empty;
                this.Order.Text = String.Empty;
            }
            catch (Exception ex)
            {

            }
        }
        private Stop_Route GetStopRouteFromRow(int index)
        {
            var row = GridViewStopRoute.Rows[index];
            //return HRFunctions.Instance.Stop_Route_Select_ID(int.Parse(row.Cells[1].Text));
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
            if (HRFunctions.Instance.InsertNUpdateStopRoute(sr) > 0)
            {
                ShowMessage("Thêm Lộ trình - điểm dừng thành công");
            }
            else
            {
                ShowMessage("Thêm Lộ trình - điểm dừng thất bại");
            }
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
            int.TryParse(this.IDStopRoute.Text, out StopRouteID);

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
            if (HRFunctions.Instance.InsertNUpdateStopRoute(sr) > 0)
            {
                ShowMessage("Cập nhật thành công");
            }
            else
            {
                ShowMessage("Cập nhật thất bại");
            }
            Refresh();
            ClearText();

        }
        private void ShowMessage(string myStringVariable)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void GridViewStopRoute_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[0].ForeColor = Color.DarkOrange;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Mã Lộ trình-Điểm dừng";
                e.Row.Cells[4].Text = "Thứ tự";
                e.Row.Cells[5].Text = "Tên Lộ trình";
                e.Row.Cells[6].Text = "Tên Điểm dừng";
            }

        }
    }
}
