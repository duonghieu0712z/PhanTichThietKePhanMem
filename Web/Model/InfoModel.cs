using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Model
{
    public class InfoModel
    {
        public RoutesModel route = null;
        public List<BusStopModel> listBusStop = null;
        public InfoModel(List<BusStop> busStops , Route route)
        {
            listBusStop = new List<BusStopModel> ();
            this.route = new RoutesModel(route);
            busStops.ForEach((item) =>
            {
                listBusStop.Add(new BusStopModel(item));
            });
        }
    }
}