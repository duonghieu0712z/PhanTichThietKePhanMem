using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Pages
{
    public partial class AddData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            test_file.Text = Server.MapPath("~/Templates/template.cfg");
        }
        public void LoadJson()
        {
            string listProduct = Server.MapPath("~/SetImg/data/Dalat_BaoLoc/bustop.json");
            string listRoute = Server.MapPath("~/SetImg/data/Dalat_BaoLoc/route.json");
            Dictionary<BusRoute, List<BusStop>> map = new Dictionary<BusRoute, List<BusStop>>();


            BusRoute busRoute;
            List<BusStop> busStops = new List<BusStop>();
            using (StreamReader r = new StreamReader(listRoute))
            {
                string json = r.ReadToEnd();
                ItemRoute itemRoute = JsonConvert.DeserializeObject<ItemRoute>(json);
                busRoute = ConvertBusRoute(itemRoute);

            }
            using (StreamReader r = new StreamReader(listProduct))
            {
                string json = r.ReadToEnd();
                List<Item> listItem = JsonConvert.DeserializeObject<List<Item>>(json);
                foreach (var item in listItem)
                {
                    busStops.Add(ConvertBusstop(item));
                }
            }

            map.Add(busRoute, busStops);


            foreach (var item in map)
            {
                List<Route> routes = new List<Route>();
                int countBusRoute = item.Value.Count;
                int countRoute = routes.Count;
                routes.Add(ConvertRoute(item.Key, item.Value[0], item.Value[countBusRoute - 1]));
                int countBusStop = item.Value.Count;
                routes.Add(ConvertRoute(item.Key, item.Value[countBusRoute - 1], item.Value[0]));
                for (int i = 0; i < countBusRoute; i++)
                {
                    int stt = i + 1;
                    ConvertStopRoute(routes[countRoute].RouteID, item.Value[i].BusStopID, stt);
                    ConvertStopRoute(routes[countRoute + 1].RouteID, item.Value[countBusRoute - stt].BusStopID, stt);
                }
            }



            //List<string> listProduct = new List<string>();
            // List<string> listRoute = new List<string>();
            //for (int i = 0; i < 5; i++)
            //{
            //    listProduct.Add(Server.MapPath("~/SetImg/data/product_" + i + ".json"));
            //    listRoute.Add(Server.MapPath("~/SetImg/data/route_" + i + ".json"));
            //}
            //Dictionary<BusRoute, List<BusStop>> map = new Dictionary<BusRoute, List<BusStop>>();

            //for (int i = 0; i < listProduct.Count; i++)
            //{
            //    BusRoute busRoute;
            //    List<BusStop> busStops = new List<BusStop>();
            //    using (StreamReader r = new StreamReader(listRoute[i]))
            //    {
            //        string json = r.ReadToEnd();
            //        ItemRoute itemRoute = JsonConvert.DeserializeObject<ItemRoute>(json);
            //        busRoute = ConvertBusRoute(itemRoute);

            //    }
            //    using (StreamReader r = new StreamReader(listProduct[i]))
            //    {
            //        string json = r.ReadToEnd();
            //        List<Item> listItem = JsonConvert.DeserializeObject<List<Item>>(json);
            //        foreach (var item in listItem)
            //        {
            //            busStops.Add(ConvertBusstop(item));
            //        }
            //    }

            //    map.Add(busRoute, busStops);
            //}

            //foreach (var item in map)
            //{
            //    List<Route> routes = new List<Route>();
            //    int countBusRoute = item.Value.Count;
            //    int countRoute = routes.Count;
            //    routes.Add(ConvertRoute(item.Key, item.Value[0], item.Value[countBusRoute - 1]));
            //    int countBusStop = item.Value.Count;
            //    routes.Add(ConvertRoute(item.Key, item.Value[countBusRoute - 1], item.Value[0]));
            //    for (int i = 0; i < countBusRoute; i++)
            //    {
            //        int stt = i + 1;
            //        ConvertStopRoute(routes[countRoute].RouteID, item.Value[i].BusStopID, stt);
            //        ConvertStopRoute(routes[countRoute+1].RouteID, item.Value[countBusRoute-stt].BusStopID, stt);
            //    }
            //}
        }



        private BusRoute ConvertBusRoute(ItemRoute itemRoute)
        {
            Random rnd = new Random();
            BusRoute busRoute = new BusRoute()
            {
                RouteNumber = itemRoute.RouteNo,
                RouteName = itemRoute.routeName,
                ResponsibleUnitID = itemRoute.ResponsibleUnitID,
                OperationType = "Phổ thông - Có trợ giá",
                OperationTime = DateTime.Now,
                Fare = itemRoute.Fare,
                BusesAmount = rnd.Next(1, 20),
                BusesTime = DateTime.Now,
                BusesSpace = DateTime.Now,
            };
            busRoute.BusRouteID = HRFunctions.Instance.InsertNUpdateBusRoute(busRoute);
            return busRoute;
        }
        private BusStop ConvertBusstop(Item item)
        {

            BusStop busStop = new BusStop()
            {
                BusStopName = item.Name,
                BusStopDescription = item.AddressNo,
                Latitude = item.Lat,
                Longitude = item.Lng,
                Street = item.Street,
                Wards = item.Ward,
                District = item.Zone,
            };
            busStop.BusStopID = HRFunctions.Instance.InsertNUpdateBusStop(busStop);
            return busStop;
        }
        private Route ConvertRoute(BusRoute busRoute, BusStop startPoint, BusStop endPoint)
        {
            Random rnd = new Random();
            TimeSpan operationDuration = TimeSpan.FromMinutes(rnd.Next(20, 60));
            Route route = new Route
            {
                BusRoutesID = busRoute.BusRouteID,
                StartPositionID = startPoint.BusStopID,
                EndPositionID = endPoint.BusStopID,
                RouteName = busRoute.RouteName + ":" + startPoint.BusStopName + "-" + endPoint.BusStopName,
                RouteTime = operationDuration,
                StartTime = DateTime.Today.AddDays(-3),
                EndTime = DateTime.Today.AddDays(4),
                ApplicableDate = DateTime.Today.AddDays(-100),
                OperationDate = DateTime.Now,
            };
            route.RouteID = HRFunctions.Instance.InsertNUpdateRoute(route);
            return route;
        }
        private Stop_Route ConvertStopRoute(int roundId, int EndPositonID, int oder)
        {

            Stop_Route stop_Route = new Stop_Route
            {
                RouteID = roundId,
                EndPositionID = EndPositonID,
                Order = oder
            };
            stop_Route.StopRouteID = HRFunctions.Instance.InsertNUpdateStopRoute(stop_Route);
            return stop_Route;
        }

        public class Item
        {
            public string AddressNo;
            public string Code;
            public float Lat;
            public float Lng;
            public string light;
            public string Name;
            public string Routes;
            public string Search;
            public string Status;
            public string Street;
            public int StopId;
            public string StopType;
            public string Ward;
            public string Zone;
        }
        public class ItemRoute
        {
            public string RouteNo;
            public string BusRouteID;
            public string PhoneNumber;
            public string routeName;
            public int ResponsibleUnitID;
            public string OperationType;
            public int Fare;
        }

        protected void btn_add_data_Click(object sender, EventArgs e)
        {
            LoadJson();
        }
    }
}