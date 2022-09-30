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

namespace Web.Pages
{

    public partial class UISearchRoute : System.Web.UI.Page
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
            this.GridViewSearchRoute.Visible = true;
            this.lblRoute.Visible = true;

        }
        private void BindingRouteData()
        {
            this.GridViewSearchRoute.DataSource = HRFunctions.Instance.SearchRouteByStartAndEndPos(int.Parse(this.dlStartPosition.SelectedValue), int.Parse(this.dlEndPosition.SelectedValue));
            this.GridViewSearchRoute.DataBind();
        }

        protected void GridViewSearchRoute_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            e.Row.Cells[0].ForeColor = Color.DarkOrange;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
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