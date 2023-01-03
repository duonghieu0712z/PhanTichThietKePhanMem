using BusinessLayer.DBAccess;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class PathInfo
    {
        public Route Route { get; set; }

        public List<BusStop> BusStops { get; set; } = new List<BusStop>();
    }
}
