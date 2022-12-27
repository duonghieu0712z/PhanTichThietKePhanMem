using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Model
{
    public class BusStopModel
    {
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
}