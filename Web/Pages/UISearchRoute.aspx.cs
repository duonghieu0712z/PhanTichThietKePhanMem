using BusinessLayer.Functions;
using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Pages
{
    public partial class UISearchRoute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Tra cứu thông tin lộ trình";
            if (!IsPostBack)
            {
                Refresh();
            }
        }
        private void Refresh()
        {
            BindingPositionData();
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
            this.GridViewSearchBusStop.DataSource = HRFunctions.Instance.GetBusStopByRoute(routeID);
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
    }
}