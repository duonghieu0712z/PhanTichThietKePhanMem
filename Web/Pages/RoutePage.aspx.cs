using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using System;

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
            HRFunctions.Instance.InsertNUpdateRoute(route);
            onTestGetData();
            Refresh();
            try
            {
                ClearText();
            }
            catch (Exception ex) { }
        }

        private void Refresh()
        {
            GridViewRoute.DataSource = HRFunctions.Instance.SelectAllRoute();
            GridViewRoute.DataBind();
            BindingDLBusRoutes();
            BindingDLStartPosition();
            BindingDLEndPosition();
        }
        private void BindingDLBusRoutes()
        {
            this.dlIDBusRoutes.DataSource = HRFunctions.Instance.SelectAllRoute();
            this.dlIDBusRoutes.DataValueField = "BusRoutesID";
            this.dlIDBusRoutes.DataTextField = "BusRoutesID";
            this.dlIDBusRoutes.DataBind();
        }
        private void BindingDLStartPosition()
        {
            this.dlIDStartPosition.DataSource = HRFunctions.Instance.SelectAllRoute();
            this.dlIDStartPosition.DataValueField = "StartPositionID";
            this.dlIDStartPosition.DataTextField = "StartPositionID";
            this.dlIDStartPosition.DataBind();
        }
        private void BindingDLEndPosition()
        {
            this.dlIDEndPosition.DataSource = HRFunctions.Instance.SelectAllRoute();
            this.dlIDEndPosition.DataValueField = "EndPositionID";
            this.dlIDEndPosition.DataTextField = "EndPositionID";
            this.dlIDEndPosition.DataBind();
        }
        private void ClearText()
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
        }

        private void onTestGetData()
        {
            //Route route = GetRoute();

            //this.TestPlace.Text = $"ID: {route.RouteID} \n" +
            //    $"IDBusRoute: {route.BusRoutesID}\n" +
            //    $"IDStartPoint: {route.StartPositionID} \n" +
            //    $"IDEndPoint: {route.EndPositionID}\n" +
            //    $"RouteName: {route.RouteName}\n" +
            //    $"RouteAmount: {route.RouteAmount}\n" +
            //    $"RouteTime: {route.RouteTime}\n" +
            //    $"RouteStartActiveTime: {route.StartTime}\n" +
            //    $"RouteFinishActiveTime: {route.EndTime}\n" +
            //    $"Applicable: {route.ApplicableDate}\n" +
            //    $"Operation: {route.OperationDate}";
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

            //route.RouteID = IDRoute;
            //route.BusRoutesID = IDBusRoutes;
            //route.StartPositionID = IDStartPoint;
            //route.EndPositionID = IDEndPoint;
            //route.RouteName = RouteName;
            //route.RouteAmount = RouteAmount;
            //route.RouteTime = RouteTime;
            //route.StartTime = RouteStartActiveTime;
            //route.EndTime = RouteFinishActiveTime;
            //route.ApplicableDate = RouteApplicable;
            //route.OperationDate = RouteOperation;
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
            HRFunctions.Instance.InsertNUpdateRoute(route);
            onTestGetData();
            Refresh();
        }
    }
}
