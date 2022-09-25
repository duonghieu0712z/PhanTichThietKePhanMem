using BusinessLayer.DBAccess;
using BusinessLayer.System.Object;
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



    }
}
