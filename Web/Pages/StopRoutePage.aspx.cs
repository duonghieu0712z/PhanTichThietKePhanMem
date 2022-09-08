﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.DBAccess;

namespace Web.Pages
{
    public partial class StopRoutePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAddStopRoute_Click(object sender, EventArgs e)
        {
            onTestGetStopRoute();
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
            int Orther= 0;
               
            int.TryParse(this.StopRouteIDStopRoute.Text, out StopRouteID);
            int.TryParse(this.StopRouteIDRoute.Text, out RouteID);
            int.TryParse(this.StopRouteIDStoping.Text, out EndPositionID);
            int.TryParse(this.StopRouteOrder.Text, out Orther);

            stopRoute.StopRouteID = StopRouteID;
            stopRoute.RouteID = RouteID;
            stopRoute.EndPositionID = EndPositionID;
            stopRoute.Order = Orther;

            return stopRoute;
        }
    }
}