using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;
using Route = BusinessLayer.DBAccess.Route;

namespace Web.Pages
{

    public partial class UISearchRoute : System.Web.UI.Page
    {
        public List<Route> RouteList = new List<Route>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Tìm kiếm Lộ trình";
            if (!IsPostBack)
            {
                Refresh();
            }
        }
        private void Refresh()
        {
            BindingPositionData();
            lblRoute.Visible = false;
        }

        private void BindingPositionData()
        {
            this.dlStartPosition.DataSource = HRFunctions.Instance.SelectAllBusStop();
            this.dlStartPosition.DataValueField = "BusStopID";
            this.dlStartPosition.DataTextField = "BusStopName";
            this.dlStartPosition.DataBind();

            this.dlEndPosition.DataSource = HRFunctions.Instance.SelectAllBusStop();
            this.dlEndPosition.DataValueField = "BusStopID";
            this.dlEndPosition.DataTextField = "BusStopName";
            this.dlEndPosition.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ClearData();
            BindingRouteData();
            this.GridViewSearchRoute.Visible = false;
            this.lblRoute.Visible = true;
            this.RepeatRoute.Visible = true;

        }
        private void BindingRouteData()
        {
            this.GridViewSearchRoute.DataSource = HRFunctions.Instance.SearchRouteByStartAndEndPos(int.Parse(this.dlStartPosition.SelectedValue), int.Parse(this.dlEndPosition.SelectedValue));
            this.GridViewSearchRoute.DataBind();

            this.RepeatRoute.DataSource = HRFunctions.Instance.SearchRouteByStartAndEndPos(int.Parse(this.dlStartPosition.SelectedValue), int.Parse(this.dlEndPosition.SelectedValue));
            this.RepeatRoute.DataBind();

            RouteList = HRFunctions.Instance.SearchRouteByStartAndEndPos(int.Parse(this.dlStartPosition.SelectedValue), int.Parse(this.dlEndPosition.SelectedValue));
        }

        protected void GridViewSearchRoute_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            e.Row.Cells[0].ForeColor = Color.DarkOrange;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[5].Text = "Tên lộ trình";
                e.Row.Cells[6].Text = "Số chuyến";
                e.Row.Cells[7].Text = "Thời gian chuyến";
                e.Row.Cells[8].Text = "Thời gian bắt đầu";
                e.Row.Cells[9].Text = "Thời gian kết thúc";
                e.Row.Cells[10].Text = "Ngày áp dụng";
                e.Row.Cells[11].Text = "Ngày hoạt động";
            }
        }

        private void BindingBusStopData(int routeID)
        {
            List<BusStop> busStops = HRFunctions.Instance.GetBusStopByRoute(routeID);
            this.GridViewSearchBusStop.DataSource = busStops;
            this.RepeaterBusStops.DataSource = busStops;
            this.RepeaterBusStops.DataBind();
            List<BusStopModel> list = new List<BusStopModel>();
            busStops.ForEach(item =>
            {
                list.Add(new BusStopModel(item));
            });
            hfData.Value = JsonConvert.SerializeObject(list);
            this.GridViewSearchBusStop.DataBind();
        }

        protected void GridViewSearchRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = this.GridViewSearchRoute.Rows[this.GridViewSearchRoute.SelectedIndex];
            int routeID = int.Parse(row.Cells[1].Text);

            BindingBusStopData(routeID);
            this.GridViewSearchBusStop.Visible = true;
        }

        protected void GridViewSearchBusStop_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Tên Điểm dừng";
                e.Row.Cells[2].Text = "Mô tả";
                e.Row.Cells[5].Text = "Tên đường";
                e.Row.Cells[6].Text = "Khu vực";
                e.Row.Cells[7].Text = "Quận";
            }
        }
        private void ClearData()
        {
            this.GridViewSearchBusStop.DataSource = null;
            this.GridViewSearchBusStop.DataBind();
            this.GridViewSearchBusStop.Visible = false;
            hfData.Value = "";
            this.GridViewSearchRoute.DataSource = null;
            this.GridViewSearchRoute.DataBind();
            this.GridViewSearchRoute.Visible = false;

            this.RepeatRoute.DataSource = null;
            this.RepeatRoute.DataBind();
            this.RepeatRoute.Visible = false;

            this.RepeaterBusStops.DataSource = null;
            this.RepeaterBusStops.DataBind();
            this.RepeaterBusStops.Visible = false;
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

        protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            ClearData();
            BindingRouteData();
            this.GridViewSearchRoute.Visible = false;
            this.lblRoute.Visible = true;
            this.RepeatRoute.Visible = true;
        }

        protected void TrRoute_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "RouteClick")
            {
                BindingBusStopData(int.Parse(e.CommandArgument.ToString()));
                this.GridViewSearchBusStop.Visible = false;
                this.RepeaterBusStops.Visible = true;
                lblBusStops.Visible = true;
            }
        }

        public static BusStop findNearPoint(Location point, List<BusStop> lsBusStop)
        {
            List<double> distances = new List<double>();

            //int minValue = distances.Sort

            foreach (var busStop in lsBusStop)
            {
                double distance = HRFunctions.deg2rad(HRFunctions.getDistanceFromLatLonInKm(point.latitudes, point.longitudes, busStop.Latitude, busStop.Longitude));
                distances.Add(distance);
            }
            double minDistance = Double.MaxValue;

            foreach (var value in distances)
            {
                if (value < minDistance)
                {
                    minDistance = value;
                }
            }
            int minIndex = distances.IndexOf(minDistance);
            Console.WriteLine(minIndex.ToString());
            return lsBusStop[minIndex];
        }


        [WebMethod]
        public static List<BusStopModel> findNearByBusStop(Location start, Location end)
        {
            List<BusStop> list = HRFunctions.Instance.SelectAllBusStop();
            List<BusStopModel> lsBusStops = new List<BusStopModel>();
            BusStopModel busStopStart = new BusStopModel(findNearPoint(start, list));
            BusStopModel busStopEnd = new BusStopModel(findNearPoint(end, list));

            lsBusStops.Add(busStopStart);
            lsBusStops.Add(busStopEnd);

            return lsBusStops;

        }
    }
}