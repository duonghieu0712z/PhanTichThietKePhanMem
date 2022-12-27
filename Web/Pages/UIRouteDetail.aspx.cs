using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Pages
{
    public partial class UIRouteDetail : System.Web.UI.Page
    {
        public BusRoute br = null;
        public List<Route> bst = null;
        public  List<BusStop> busStops = null;
        public int index;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);
                br = HRFunctions.Instance.Select_Bus_Route_ID(id);
                bst = HRFunctions.Instance.SearchRouteByBusRouteId(id);
                busStops = HRFunctions.Instance.GetBusStopByRoute(id);
            }
            catch { Response.Redirect("/Pages/UIBusRoute"); };
        }

    }
}