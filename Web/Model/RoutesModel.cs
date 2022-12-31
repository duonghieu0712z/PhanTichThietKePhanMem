using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Web.Model
{
    public class RoutesModel
    {

        public int RouteID { get; set; }
        public int BusRoutesID { get; set; }
        public int StartPositionID { get; set; }
        public int EndPositionID { get; set; }
        public string RouteName { get; set; }
        public int RouteAmount { get; set; }

        public RoutesModel(Route route)
        {
            RouteID = route.RouteID;
            BusRoutesID = route.BusRoutesID;
            StartPositionID = route.StartPositionID;
            EndPositionID = route.EndPositionID;
            RouteName = route.RouteName;
            RouteAmount = route.RouteAmount;
        }
    }
}