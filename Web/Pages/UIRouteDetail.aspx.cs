using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Web.Pages
{
    public partial class UIRouteDetail : System.Web.UI.Page
    {
        public BusRoute br = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);
                br = HRFunctions.Instance.Select_Bus_Route_ID(id);
                BinddingRouteData(id);
            }
            catch { Response.Redirect("/Pages/UIBusRoute"); };
        }

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

        private void BinddingRouteData(int BusRouteID)
        {
            this.RepeatRoute.DataSource = HRFunctions.Instance.SearchRouteByBusRouteId(BusRouteID);
            this.RepeatRoute.DataBind();
            this.RepeatRoute.Visible = true;
        }

        private void BindingBusStopData(int routeID)
        {
            List<BusStop> busStops = HRFunctions.Instance.GetBusStopByRoute(routeID);
            this.RepeaterBusStops.DataSource = busStops;
            this.RepeaterBusStops.DataBind();
            List<BusStopModel> list = new List<BusStopModel>();
            busStops.ForEach(item =>
            {
                list.Add(new BusStopModel(item));
            });
            hfData.Value = JsonConvert.SerializeObject(list);
        }

        protected void TrRoute_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            if (e.CommandName == "RouteClick")
            {
                BindingBusStopData(int.Parse(e.CommandArgument.ToString()));
                //this.GridViewSearchBusStop.Visible = false;
                this.RepeaterBusStops.Visible = true;
                this.lblBusStops.Visible = true;
            }
        }
    }
}