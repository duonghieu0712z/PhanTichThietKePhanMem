using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class RouteInfo
    {
        public int RouteID { get; set; }
        public int BusRoutesID { get; set; }
        public int StartPositionID { get; set; }
        public int EndPositionID { get; set; }
        public string RouteName { get; set; }
        public int RouteAmount { get; set; }
        public System.TimeSpan RouteTime { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public System.DateTime ApplicableDate { get; set; }
        public System.DateTime OperationDate { get; set; }
        public string BusRoutesName { get; set; }
        public string BusStopStart { get; set; }
        public string BusStopEnd { get; set; }
    }
}
