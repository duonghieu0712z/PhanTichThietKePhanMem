using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class Stop_RouteInfo
    {
        public int StopRouteID { get; set; }
        public int RouteID { get; set; }
        public int EndPositionID { get; set; }
        public int Order { get; set; }
        public string RouteName { get; set; }
        public string BusStopName { get; set; }
    }
}
