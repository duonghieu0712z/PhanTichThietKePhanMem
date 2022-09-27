using BusinessLayer.DBAccess;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RouteExt : RouteFuncs
    {
        private static RouteExt instance = null;
        public static RouteExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new RouteExt();
                return instance;
            }
        }

        public List<RouteInfo> GetAllRouteInfo()
        {
            using (var db = GetContext())
            {
                var ls = db.Routes.Join(db.BusRoutes, r => r.BusRoutesID, br => br.BusRouteID, (r, br) => new RouteInfo()
                {
                    RouteID = r.RouteID,
                    BusRoutesID = r.BusRoutesID,
                    StartPositionID = r.StartPositionID,
                    EndPositionID = r.EndPositionID,
                    RouteName = r.RouteName,
                    RouteAmount = r.RouteAmount,
                    RouteTime = r.RouteTime,
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,
                    ApplicableDate = r.ApplicableDate,
                    OperationDate = r.OperationDate,
                    BusRoutesName = br.RouteName,
                }).Join(db.BusStops, r => r.StartPositionID, bs => bs.BusStopID, delegate (RouteInfo r, BusStop bs)
                {
                    r.BusStopStart = bs.BusStopName;
                    return r;
                }).Join(db.BusStops, r => r.EndPositionID, bs => bs.BusStopID, delegate (RouteInfo r, BusStop bs)
                {
                    r.BusStopEnd = bs.BusStopName;
                    return r;
                });
                if (ls != null && ls.Any()) return ls.ToList();
                return new List<RouteInfo>();
            }
        }

        public List<Route> SearchRouteByStartAndEndPos(int idStart, int idEnd)
        {
            using (var db = GetContext())
            {
                var start = db.Stop_Route.Where(sr => sr.EndPositionID == idStart).Select(sr => sr.RouteID);
                var end = db.Stop_Route.Where(sr => sr.EndPositionID == idEnd).Select(sr => sr.RouteID);
                var inter = start.Intersect(end);
                var ls = db.Routes.Join(inter, r => r.RouteID, i => i, (r, i) => r);

                if (ls != null && ls.Any()) return ls.ToList();
                return new List<Route>();
            }
        }
    }
}
