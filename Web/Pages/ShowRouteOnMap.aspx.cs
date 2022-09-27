using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Description;
using WebGrease.Css.Extensions;

namespace Web.Pages
{
   

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


      
    }

}