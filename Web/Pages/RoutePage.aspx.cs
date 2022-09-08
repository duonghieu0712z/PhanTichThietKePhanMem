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
        }

        protected void ButtonAddRoute_Click(object sender, EventArgs e)
        {
            Route route = GetRoute();
            HRFunctions.Instance.InsertNUpdateRoute(route);
            onTestGetData();
            Refresh();
            ClearText();
        }

        private void Refresh()
        {
            GridViewRoute.DataSource = HRFunctions.Instance.SelectAllRoute();
            GridViewRoute.DataBind();
        }

        private void ClearText()
        {
            RouteIDRoute.Text = string.Empty;
            RouteIDBusRoute.Text = string.Empty;
            RouteIDStartPoint.Text = string.Empty;
            RouteIDEndPoint.Text = string.Empty;
            RouteRouteName.Text = string.Empty;
            RoutesNumber.Text = string.Empty;
            RoutesTime.Text = string.Empty;
            RouteStartActiveTime.Text = string.Empty;
            RouteFinishActiveTime.Text = string.Empty;
            RouteApplicable.Text = string.Empty;
            RouteIDRoute.Text = string.Empty;
        }

        private void onTestGetData()
        {
            Route route = GetRoute();

            this.TestPlace.Text = $"ID: {route.RouteID} \n" +
                $"IDBusRoute: {route.BusRoutesID}\n" +
                $"IDStartPoint: {route.StartPositionID} \n" +
                $"IDEndPoint: {route.EndPositionID}\n" +
                $"RouteName: {route.RouteName}\n" +
                $"RouteAmount: {route.RouteAmount}\n" +
                $"RouteTime: {route.RouteTime}\n" +
                $"RouteStartActiveTime: {route.StartTime}\n" +
                $"RouteFinishActiveTime: {route.EndTime}\n" +
                $"Applicable: {route.ApplicableDate}\n" +
                $"Operation: {route.OperationDate}";
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

            int.TryParse(this.RouteIDRoute.Text, out IDRoute);
            int.TryParse(this.RouteIDBusRoute.Text, out IDBusRoutes);
            int.TryParse(this.RouteIDStartPoint.Text, out IDStartPoint);
            int.TryParse(this.RouteIDEndPoint.Text, out IDEndPoint);
            RouteName = this.RouteRouteName.Text;
            int.TryParse(this.RoutesNumber.Text, out RouteAmount);
            //TimeSpan.TryParse(this.RoutesTime.Text, out RouteTime);
            if (Double.TryParse(this.RoutesTime.Text, out _doubleRouteTime))
            {
                RouteTime = TimeSpan.FromMinutes(_doubleRouteTime);
            }

            DateTime.TryParse(this.RouteStartActiveTime.Text, out var RouteStartActiveTime);
            DateTime.TryParse(this.RouteFinishActiveTime.Text, out var RouteFinishActiveTime);
            DateTime.TryParse(this.RouteApplicable.Text, out var RouteApplicable);
            //DateTime.TryParse(this.RouteApplicable.Text, out var RouteOperation);
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
            TestPlace.Text += DateTime.Parse(row.Cells[8].Text);
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
            this.RouteIDRoute.Text = r.RouteID.ToString();
            this.RouteIDBusRoute.Text = r.BusRoutesID.ToString();
            this.RouteIDStartPoint.Text = r.StartPositionID.ToString();
            this.RouteIDEndPoint.Text = r.EndPositionID.ToString();
            this.RouteRouteName.Text = r.RouteName.ToString();
            this.RoutesNumber.Text = r.RouteAmount.ToString();
            this.RoutesTime.Text = r.RouteTime.ToString();
            this.RouteStartActiveTime.Text = r.StartTime.ToString("HH:mm");
            this.RouteFinishActiveTime.Text = r.EndTime.ToString("HH:mm");
            this.RouteApplicable.Text = r.ApplicableDate.ToString("yyyy-MM-dd");
            this.RouteOperation.Text = r.OperationDate.ToString();
        }

        protected void ButtonDeleteRoute_Click(object sender, EventArgs e)
        {
            int.TryParse(this.RouteIDRoute.Text, out var id);
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
