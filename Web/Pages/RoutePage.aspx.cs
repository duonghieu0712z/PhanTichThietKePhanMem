using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.DBAccess;

namespace Web.Pages
{
    public partial class RoutePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RoutesNumber.Text = "Hello";
            }
            Page.Title = "Quản lý lộ trình";
        }

        protected void ButtonAddRoute_Click(object sender, EventArgs e)
        {
            onTestGetData();
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
            DateTime RouteStartActiveTime = DateTime.Parse(this.RouteStartActiveTime.Text);
            DateTime RouteFinishActiveTime = DateTime.Parse(this.RouteFinishActiveTime.Text);

            DateTime RouteApplicable = DateTime.Parse(this.RouteApplicable.Text);
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

        private void SetRouteData(Route r)
        {
            this.RouteIDRoute.Text = r.RouteID.ToString();
            this.RouteIDBusRoute.Text = r.BusRoutesID.ToString();
            this.RouteIDStartPoint.Text = r.StartPositionID.ToString();
            this.RouteIDEndPoint.Text = r.EndPositionID.ToString();
            this.RouteRouteName.Text = r.RouteName.ToString();
            this.RoutesNumber.Text = r.RouteAmount.ToString();
            this.RoutesTime.Text = r.RouteTime.ToString();
            this.RouteStartActiveTime.Text = r.StartTime.ToString();
            this.RouteFinishActiveTime.Text = r.EndTime.ToString();
            this.RouteApplicable.Text = r.ApplicableDate.ToString();
            this.RouteOperation.Text = r.OperationDate.ToString();
        }
    }
}