using BusinessLayer.DBAccess;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Models;

namespace BusinessLayer.Functions
{
    public class HRFunctions : BaseFunctions
    {
        private static HRFunctions instance = null;
        public static HRFunctions Instance
        {
            get
            {
                if (instance == null)
                    instance = new HRFunctions();
                return instance;
            }
        }
        public List<Route> SelectAllRoute()
        {
            return RouteExt.Instance.Route_Select_All();
        }
        public List<Stop_Route> SelectAllStopRoute()
        {
            return StopRouteExt.Instance.Stop_Route_Select_All();
        }
        public List<BusRoute> SelectAllBusRoute()
        {
            return BusRouteExt.Instance.BusRoute_Select_All();
        }
        public List<BusStop> SelectAllBusStop()
        {
            return BusStopExt.Instance.BusStop_Select_All();
        }

        public int InsertNUpdateRoute(Route route)
        {
            return RouteExt.Instance.Route_InsertUpdate(route);
        }
        public int InsertNUpdateStopRoute(Stop_Route stop_Route)
        {
            return StopRouteExt.Instance.Stop_Route_InsertUpdate(stop_Route);
        }

        public void DeleteRoute(int id)
        {
            RouteExt.Instance.Route_Delete(id);
        }
        public void DeleteStopRoute(int id)
        {
            StopRouteExt.Instance.Stop_Route_Delete(id);
        }

        public Stop_Route Stop_Route_Select_ID(int id)
        {
            return StopRouteExt.Instance.Stop_Route_Select_ID(id);
        }

        public List<RouteInfo> GetAllRouteInfo()
        {
            return RouteExt.Instance.GetAllRouteInfo();
        }
        public List<Stop_RouteInfo> GetAllStopRouteInfo()
        {
            return StopRouteExt.Instance.GetAllStopRouteInfo();
        }

        public List<Route> SearchRouteByStartAndEndPos(int idStart, int idEnd)
        {
            return RouteExt.Instance.SearchRouteByStartAndEndPos(idStart, idEnd);
        }

        public List<BusStop> GetBusStopByRoute(int routeId)
        {
            return StopRouteExt.Instance.GetBusStopByRoute(routeId);
        }

        public BusStop BusStop_Select_ID(int id)
        {
            return BusStopExt.Instance.BusStop_Select_ID(id);
        }
    }
}
