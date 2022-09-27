using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using System;
using System.Web.UI.WebControls;

namespace Web.Pages
{
    public partial class RoutePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Refresh();
            }
            Page.Title = "Quản lý lộ trình";
        }

        protected void ButtonAddRoute_Click(object sender, EventArgs e)
        {
            Route route = GetRoute();
            if (HRFunctions.Instance.InsertNUpdateRoute(route) > 0)
            {
                ShowMessage("Thêm lộ trình thành công");
            }
            else
            {
                ShowMessage("Thêm lộ trình thất bại");
            }

            Refresh();
            ClearText();
        }

        private void Refresh()
        {
            //GridViewRoute.DataSource = HRFunctions.Instance.SelectAllRoute();
            GridViewRoute.DataSource = HRFunctions.Instance.GetAllRouteInfo();
            GridViewRoute.DataBind();
            BindingDLBusRoutes();
            BindingDLStartPosition();
            BindingDLEndPosition();
        }
        private void BindingDLBusRoutes()
        {
            this.dlIDBusRoutes.DataSource = HRFunctions.Instance.SelectAllBusRoute();
            this.dlIDBusRoutes.DataValueField = "BusRouteID";
            this.dlIDBusRoutes.DataTextField = "RouteName";
            this.dlIDBusRoutes.DataBind();
        }
        private void BindingDLStartPosition()
        {
            this.dlIDStartPosition.DataSource = HRFunctions.Instance.SelectAllBusStop();
            this.dlIDStartPosition.DataValueField = "BusStopID";
            this.dlIDStartPosition.DataTextField = "BusStopName";
            this.dlIDStartPosition.DataBind();
        }
        private void BindingDLEndPosition()
        {
            this.dlIDEndPosition.DataSource = HRFunctions.Instance.SelectAllBusStop();
            this.dlIDEndPosition.DataValueField = "BusStopID";
            this.dlIDEndPosition.DataTextField = "BusStopName";
            this.dlIDEndPosition.DataBind();
        }
        private void ClearText()
        {
            try
            {
                this.IDRoute.Text = String.Empty;
                this.RouteName.Text = String.Empty;
                this.dlIDBusRoutes.SelectedValue = String.Empty;
                this.dlIDStartPosition.SelectedValue = String.Empty;
                this.dlIDEndPosition.SelectedValue = String.Empty;

                this.RouteAmount.Text = String.Empty;
                this.RouteTime.Text = String.Empty;
                this.StartTime.Text = String.Empty;
                this.EndTime.Text = String.Empty;
                this.OperationDate.ClearSelection();
                this.ApplicableDate.Text = String.Empty;

                this.GridViewRoute.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

            }
        }

        private Route GetRoute()
        {
            Route route = new Route();
            int IDRoute = -1;
            int IDBusRoutes = -1;
            int IDStartPoint = -1;
            int IDEndPoint = -1;
            string RouteName;
            int RouteAmount = 0;
            double _doubleRouteTime = 0;
            TimeSpan RouteTime = TimeSpan.Zero;

            int.TryParse(this.IDRoute.Text, out IDRoute);
            int.TryParse(this.dlIDBusRoutes.SelectedValue, out IDBusRoutes);
            int.TryParse(this.dlIDStartPosition.SelectedValue, out IDStartPoint);
            int.TryParse(this.dlIDEndPosition.SelectedValue, out IDEndPoint);
            RouteName = this.RouteName.Text;
            int.TryParse(this.RouteAmount.Text, out RouteAmount);
            TimeSpan.TryParse(this.RouteTime.Text, out RouteTime);
            if (Double.TryParse(this.RouteTime.Text, out _doubleRouteTime))
            {
                RouteTime = TimeSpan.FromMinutes(_doubleRouteTime);
            }

            DateTime.TryParse(this.StartTime.Text, out var RouteStartActiveTime);
            DateTime.TryParse(this.EndTime.Text, out var RouteFinishActiveTime);
            DateTime.TryParse(this.ApplicableDate.Text, out var RouteApplicable);
            // DateTime.TryParse(this.RouteApplicable.Text, out var RouteOperation);
            DateTime RouteOperation = DateTime.Now;

            route.RouteID = IDRoute;
            route.BusRoutesID = IDBusRoutes;
            route.StartPositionID = IDStartPoint;
            route.EndPositionID = IDEndPoint;
            route.RouteName = RouteName;
            route.RouteAmount = RouteAmount;
            route.RouteTime = RouteTime;
            route.StartTime = RouteStartActiveTime;
            route.EndTime = RouteFinishActiveTime;
            route.ApplicableDate = RouteApplicable;
            route.OperationDate = RouteOperation;
            return route;
        }

        private Route GetRouteFromRow(int index)
        {
            var row = GridViewRoute.Rows[index];

            return new Route()
            {
                RouteID = int.Parse(row.Cells[1].Text),
                BusRoutesID = int.Parse(row.Cells[2].Text),
                StartPositionID = int.Parse(row.Cells[3].Text),
                EndPositionID = int.Parse(row.Cells[4].Text),
                RouteName = row.Cells[5].Text,
                RouteAmount = int.Parse(row.Cells[6].Text),
                RouteTime = TimeSpan.Parse(row.Cells[7].Text),
                StartTime = DateTime.Parse(row.Cells[8].Text),
                EndTime = DateTime.Parse(row.Cells[9].Text),
                ApplicableDate = DateTime.Parse(row.Cells[10].Text),
                OperationDate = DateTime.Parse(row.Cells[11].Text),
            };
        }

        private void SetRouteData(Route r)
        {
            this.IDRoute.Text = r.RouteID.ToString();
            this.RouteName.Text = r.RouteName.ToString();
            this.dlIDBusRoutes.SelectedValue = r.BusRoutesID.ToString();
            this.dlIDStartPosition.SelectedValue = r.StartPositionID.ToString();
            this.dlIDEndPosition.SelectedValue = r.EndPositionID.ToString();

            this.RouteAmount.Text = r.RouteAmount.ToString();
            this.RouteTime.Text = r.RouteTime.ToString("mm");
            this.StartTime.Text = r.StartTime.ToString("HH:mm");
            this.EndTime.Text = r.EndTime.ToString("HH:mm");
            this.OperationDate.ClearSelection();
            this.ApplicableDate.Text = r.ApplicableDate.ToString("yyyy-MM-dd");
        }

        protected void ButtonDeleteRoute_Click(object sender, EventArgs e)
        {
            int.TryParse(this.IDRoute.Text, out var id);
            HRFunctions.Instance.DeleteRoute(id);
            Refresh();
            ClearText();
        }

        protected void GridViewRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            Route route = GetRouteFromRow(GridViewRoute.SelectedIndex);
            SetRouteData(route);
        }

        protected void ButtonUpdateRoute_Click(object sender, EventArgs e)
        {
            Route route = GetRoute();
            if (HRFunctions.Instance.InsertNUpdateRoute(route) > 0)
            {
                ShowMessage("Cập nhật lộ trình thành công");
            }
            else
            {
                ShowMessage("Cập nhật lộ trình thất bại");
            }
            Refresh();
            ClearText();
        }
        private void ShowMessage(string myStringVariable)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void GridViewRoute_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Mã Lộ trình";
                e.Row.Cells[5].Text = "Tên Lộ trình";
                e.Row.Cells[6].Text = "Số chuyến";
                e.Row.Cells[7].Text = "Thời gian chuyến";
                e.Row.Cells[8].Text = "Thời gian bắt đầu";
                e.Row.Cells[9].Text = "Thời gian kết thúc";
                e.Row.Cells[10].Text = "Ngày áp dụng";
                e.Row.Cells[11].Text = "Ngày hoạt động";
                e.Row.Cells[12].Text = "Tên tuyến";
                e.Row.Cells[13].Text = "Điểm bắt đầu";
                e.Row.Cells[14].Text = "Điểm kết thúc";
            }
        }
    }
}
