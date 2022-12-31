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

        private AdjacencyGraph<BusStop, Path> graph;

        private Graph() { }

        public static Graph Instance
        {
            get
            {
                instance = instance ?? new Graph();
                return instance;
            }
        }

        private AdjacencyGraph<BusStop, Path> CreateGraph()
        {
            var graph = new AdjacencyGraph<BusStop, Path>();

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

            // TODO:

            return graph;
        }

        private BusStop FindNearestBusStop(double latitude, double longitude) => graph.Vertices.Aggregate(delegate (BusStop curr, BusStop next)
        {
            if (curr == null)
            {
                return next;
            }

            if (Utils.GeoDistance(next.Latitude, next.Longitude, latitude, longitude) < Utils.GeoDistance(curr.Latitude, curr.Longitude, latitude, longitude))
            {
                return next;
            }
            return curr;
        });

        public List<Path> FindRoute(double latSource, double longSource, double latTarget, double longTarget)
        {
            graph = CreateGraph();
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

        public List<BusStop> GetBusStops(List<Path> paths)
        {
            if (paths.Count == 0) return new List<BusStop>();

            var busStops = new List<BusStop>
            {
                paths[0].Source
            };
            foreach (var path in paths)
            {
                busStops.Add(path.Target);
            }
            return busStops;
        }

        public List<PathInfo> GetPathInfos(List<Path> paths)
        {
            if (paths.Count == 0) return new List<PathInfo>();

            var pathInfos = new List<PathInfo>();

            HashSet<int> set = paths[0].RouteIds;
            var pathInfo = new PathInfo();
            pathInfo.BusStops.Add(paths[0].Source);
            pathInfo.BusStops.Add(paths[0].Target);

            for (int i = 1; i < paths.Count; i++)
            {
                var temp = new HashSet<int>(set);
                temp.IntersectWith(paths[i].RouteIds);
                if (temp.Count == 0)
                {
                    pathInfo.Route = HRFunctions.Instance.Route_Select_ID(set.First());
                    pathInfos.Add(pathInfo);

                    set = paths[i].RouteIds;
                    pathInfo = new PathInfo();
                    pathInfo.BusStops.Add(paths[i].Source);
                    pathInfo.BusStops.Add(paths[i].Target);

                    continue;
                }
                set = temp;
                pathInfo.BusStops.Add(paths[i].Target);
            }
            pathInfo.Route = HRFunctions.Instance.Route_Select_ID(set.First());
            pathInfos.Add(pathInfo);

            return pathInfos;
        }
    }
}
