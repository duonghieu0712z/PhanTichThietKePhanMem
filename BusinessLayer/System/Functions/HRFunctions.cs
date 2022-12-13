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
        #region Route
        public List<ResponsibleUnit> Select_All_ResponsibleUnit()
        {
            return ResponsibleExt.Instance.Select_All();
        }
        public int InsertNUpdateResponsible(ResponsibleUnit resp)
        {
            return ResponsibleExt.Instance.InsertUpdate(resp);
        }
        public ResponsibleUnit Select_Responsible_Unit_ID(int id)
        {
            return ResponsibleExt.Instance.Select_ID(id);
        }
        public List<ResponsibleUnit> ResponsibleUnit_Pagination(string keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            return ResponsibleExt.Instance.Find_KeyWord(keyword, PageSize, PageIndex, out TotalRows);
        }
        public void DeleteResponsibleUnit(List<String> IDs)
        {
            ResponsibleExt.Instance.Delete_IDs(IDs);
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
        public void DeleteBusRouteByIDs(List<String> IDs)
        {
            BusRouteExt.Instance.BusRoute_Delete_IDs(IDs);

        }
        public BusRoute Select_Bus_Route_ID(int id)
        {
            return BusRouteExt.Instance.BusRoute_Select_ID(id);
        }
        public List<BusRoute> Bus_Route_Pagination(string keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            return BusRouteExt.Instance.BusRoute_Find_KeyWord(keyword, PageSize, PageIndex, out TotalRows);
        }
        public List<BusRoute> FindBusRoute(string keyword)
        {
            return BusRouteExt.Instance.BusRoute_Find(keyword);
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

        public Route Route_Select_ID(int id)
        {
            return RouteExt.Instance.Route_Select_ID(id);
        }

        public Stop_Route Stop_Route_Select_ID(int id)
        {
            return StopRouteExt.Instance.Stop_Route_Select_ID(id);
        }

        public BusStop BusStop_Select_ID(int id)
        {
            return BusStopExt.Instance.BusStop_Select_ID(id);
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

        public List<Route> SearchRouteByBusRouteId(int id)
        {
            return RouteExt.Instance.SearchRouteByBusRouteId(id);
        }

        public List<BusStop> GetBusStopByRoute(int routeId)
        {
            return StopRouteExt.Instance.GetBusStopByRoute(routeId);
        }
        #endregion

        #region BusStop
        public List<BusStop> SearchByName(string nameValue)
        {

            return BusStopExt.Instance.BusStop_Select_By("Name", nameValue);
        }

        public int InsertBusStop(BusStop bs)
        {
            return BusStopExt.Instance.BusStop_InsertUpdate(bs);
        }

        public BusStop FindBusStopByID(int id)
        {
            return BusStopExt.Instance.BusStop_Select_ID(id);
        }
        public void DeleteBusStopByID(int id)
        {
            BusStopExt.Instance.BusStop_Delete(id);
        }
        public void DeleteBusStopByIDs(List<String> IDs)
        {
            BusStopExt.Instance.BusStop_Delete_IDs(IDs);

        }
        public List<BusStop> Bus_Stop_Pagination(int PageSize, int PageIndex, out int TotalRows)
        {
            return BusStopExt.Instance.BusStop_Find_KeyWord("", PageSize, PageIndex, out TotalRows);
        }

        #endregion
    }
}
