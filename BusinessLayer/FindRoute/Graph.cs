using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using QuikGraph;
using QuikGraph.Algorithms;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Graph
    {
        private static Graph instance;

        private readonly AdjacencyGraph<BusStop, Path> graph;

        private Graph()
        {
            graph = new AdjacencyGraph<BusStop, Path>();

            var busStops = HRFunctions.Instance.SelectAllBusStop();
            graph.AddVertexRange(busStops);

            var stopRoutes = HRFunctions.Instance.SelectAllStopRoute()
                .OrderBy(s => s.RouteID)
                .ThenBy(s => s.Order)
                .ToList();

            int routeId = -1;
            BusStop source = null, target = null;
            foreach (var sr in stopRoutes)
            {
                if (routeId != sr.RouteID)
                {
                    routeId = sr.RouteID;
                    source = busStops.Find(bs => bs.BusStopID == sr.EndPositionID);
                    continue;
                }

                target = busStops.Find(bs => bs.BusStopID == sr.EndPositionID);
                if (graph.Edges.Any(p => p.Source == source && p.Target == target))
                {
                    graph.Edges.First(p => p.Source == source && p.Target == target).RouteIds.Add(routeId);
                }
                else
                {
                    graph.AddEdge(new Path(source, target, routeId));
                }
                source = target;
            }
        }

        public static Graph Instance
        {
            get
            {
                instance = instance ?? new Graph();
                return instance;
            }
        }

        private BusStop FindNearestBusStop(double latitude, double longitude) => graph.Vertices.Aggregate(delegate (BusStop curr, BusStop next)
        {
            if (curr == null)
            {
                return next;
            }

            if (Utils.Distance(next.Latitude, next.Longitude, latitude, longitude) < Utils.Distance(curr.Latitude, curr.Longitude, latitude, longitude))
            {
                return next;
            }
            return curr;
        });

        public List<Path> FindRoute(double latSource, double longSource, double latTarget, double longTarget)
        {
            var source = FindNearestBusStop(latSource, longSource);
            var target = FindNearestBusStop(latTarget, longTarget);
            return FindRoute(source, target);
        }

        private List<Path> FindRoute(BusStop source, BusStop target)
        {
            var tryGetPath = graph.ShortestPathsDijkstra(path => path.Distance, source);
            if (tryGetPath(target, out var paths))
            {
                return paths.ToList();
            }
            return new List<Path>();
        }
    }
}
