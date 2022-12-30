using BusinessLayer.DBAccess;
using QuikGraph;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class Path : IEdge<BusStop>
    {
        public Path(BusStop source, BusStop target)
        {
            Source = source;
            Target = target;
        }

        public Path(BusStop source, BusStop target, int routeId)
        {
            Source = source;
            Target = target;
            RouteIds.Add(routeId);
        }

        public BusStop Source { get; set; }

        public BusStop Target { get; set; }

        public HashSet<int> RouteIds { get; set; } = new HashSet<int>();

        public double Distance => Utils.Distance(Source.Latitude, Source.Longitude, Target.Latitude, Target.Longitude);
    }
}
