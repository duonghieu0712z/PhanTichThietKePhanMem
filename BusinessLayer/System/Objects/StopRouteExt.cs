using BusinessLayer.DBAccess;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StopRouteExt : StopRouteFuncs
    {
        private static StopRouteExt instance = null;
        public static StopRouteExt Instance
        {
            get
            {
                if (instance == null)
                    instance = new StopRouteExt();
                return instance;
            }
        }

        public List<Stop_RouteInfo> GetAllStopRouteInfo()
        {
            using (var db = GetContext())
            {
                var res = db.Stop_Route.Join(db.Routes, sr => sr.RouteID, r => r.RouteID, (sr, r) => new Stop_RouteInfo()
                {
                    StopRouteID = sr.StopRouteID,
                    RouteID = sr.RouteID,
                    EndPositionID = sr.EndPositionID,
                    Order = sr.Order,
                    RouteName = r.RouteName
                }).Join(db.BusStops, sr => sr.EndPositionID, bs => bs.BusStopID, delegate (Stop_RouteInfo sr, BusStop bs)
                {
                    sr.BusStopName = bs.BusStopName;
                    return sr;
                });
                if (res != null && res.Any()) return res.ToList();
                return new List<Stop_RouteInfo>();
            }
        }

        public List<BusStop> GetBusStopByRoute(int routeId)
        {
            using (var db = GetContext())
            {
                var res = db.Stop_Route.Where(sr => sr.RouteID == routeId).OrderBy(sr => sr.Order).Join(db.BusStops, sr => sr.EndPositionID, bs => bs.BusStopID, (sr, bs) => bs);
                if (res != null && res.Any()) return res.ToList();
                return new List<BusStop>();
            }
        }
    }
}
