using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Description;

namespace Web.Pages
{
    public class Mobile
    {
        public string ModelName { get; set; }
        public decimal Price { get; set; }
    }

    public class BusStopModel{
        public int BusStopID { get; set; }
        public string BusStopName { get; set; }
        public string BusStopDescription { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Street { get; set; }
        public string Wards { get; set; }
        public string District { get; set; }
        public BusStopModel(BusStop bus)
        {
            BusStopID = bus.BusStopID;
            BusStopName = bus.BusStopName;
            BusStopDescription = bus.BusStopDescription;
            Latitude = bus.Latitude;
            Longitude = bus.Longitude;
            Street = bus.Street;
            Wards = bus.Wards;
            District = bus.District;
        }
     
    }
    public partial class ShowRouteOnMap : System.Web.UI.Page
    {
        public string startPoint { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string update(string userdata)
        {
            Console.WriteLine("test");
            return "Posted";
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<BusStopModel> GetAllBusStop()
        {
            List<BusStopModel> list = new List<BusStopModel>();
            HRFunctions.Instance.SelectAllBusStop().ForEach(item =>
            {
                list.Add(new BusStopModel(item));
            });

            return list;
        }
        public static string SayHello(string name)
        {
            return "Hello " + name;
        }

        public void LoadJson()
        {
            List<Item> items = new List<Item>();
            using (StreamReader r = new StreamReader("E:\\PhanTichThietKePhanMem\\Web\\SetImg\\xmltojson.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Item>>(json);
            }
            List<BusStop> busStops= new List<BusStop>();
            items.ForEach(item =>
            {
                BusStop busStop = new BusStop()
                {
                        BusStopName =item.Name,
                        BusStopDescription =item.AddressNo,
                        Latitude =item.Lat,
                        Longitude =item.Lng,
                        Street =item.Street,
                        Wards =item.Ward,
                        District =item.Zone,
                    };
                HRFunctions.Instance.InsertNUpdateBusStop(busStop);
            });
           

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

        protected void btn_load_json_Click(object sender, EventArgs e)
        {
            LoadJson();
        }
    }

}