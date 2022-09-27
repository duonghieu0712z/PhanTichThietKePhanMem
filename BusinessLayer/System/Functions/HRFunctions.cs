using BusinessLayer.DBAccess;
using BusinessLayer;
using System;
using System.Collections.Generic;

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

        public int InsertNUpdateBusRoute(BusRoute busRoute)
        {
            return BusRouteExt.Instance.BusRoute_InsertUpdate(busRoute);
        }
        public int InsertNUpdateRoute(Route route)
        {
            return RouteExt.Instance.Route_InsertUpdate(route);
        }
        public int InsertNUpdateStopRoute(Stop_Route stop_Route)
        {
            return StopRouteExt.Instance.Stop_Route_InsertUpdate(stop_Route);
        }
        public int InsertNUpdateBusStop(BusStop  busStop)
        {
            return BusStopExt.Instance.BusStop_InsertUpdate(busStop);
        }

        public void DeleteRoute(int id)
        {
            RouteExt.Instance.Route_Delete(id);
        }
        public void DeleteStopRoute(int id)
        {
            StopRouteExt.Instance.Stop_Route_Delete(id);
        }
    }
}
