using BusinessLayer;
using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Pages
{
    public partial class SearchBusPage : System.Web.UI.Page
    {
        List<int> list = new List<int> { 1, 2, 3, 4, 5 };
        public List<Bus> listBus;

        int PageSize = int.Parse(Global.g_PageSize2);
        public int pivot = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hPageIndex.Value = "0";
                LoadDropDownList();
            }
            LoadListBusPage(0);
        }

        protected void LoadDropDownList()
        {
            this.BusTypeList.DataSource = HRFunctions.Instance.SelectAllBusType();
            this.BusTypeList.DataTextField = "Name";
            this.BusTypeList.DataValueField = "BusTypeID";
            this.BusTypeList.DataBind();
            this.BusTypeList.Items.Insert(0, "Tất cả");

            this.RoutesList.DataSource = HRFunctions.Instance.SelectAllBusRoutes();
            this.RoutesList.DataTextField = "RouteName";
            this.RoutesList.DataValueField = "BusRouteID";
            this.RoutesList.DataBind();
            this.RoutesList.Items.Insert(0, "Tất cả");

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            LoadListBusPage(0);
        }

        private void LoadListBusPage(int pIndex, bool isSearch = true)
        {
            string query = "";
            if (isSearch == true)
            {
                query = SearchByCriteria();
            }
            int TotalRows = 0;

            this.listBus = HRFunctions.Instance.SearchBusByCriteria(query, PageSize, pIndex, out TotalRows);

            this.hTotalRows.Value = TotalRows.ToString();
            if (listBus == null || listBus.Count == 0)
            {
                this.pnPhanTrang.Visible = false;
            }
            else
            {
                this.pnPhanTrang.Visible = true;
                LoadPhanTrang();
            }
        }

        protected string SearchByCriteria()
        {
            string licensePlate = !LicensePlate.Value.IsNullOrWhiteSpace() ? $"LicensePlates='{LicensePlate.Value}' and " : "";
            string busNumber = !BusNumber.Value.IsNullOrWhiteSpace() ? $"BusNumber='{BusNumber.Value}' and " : "";
            string sumSeats = !SumSeat.Value.IsNullOrWhiteSpace() ? $"SumSeats='{SumSeat.Value}' and " : "";
            string status = !Status.Value.IsNullOrWhiteSpace() ? $"Status=N'{Status.Value}' and " : "";
            string busType = BusTypeList.Text != "Tất cả" ? $"BusTypeID={int.Parse(this.BusTypeList.Text)} and " : "";
            string routes = RoutesList.Text != "Tất cả" ? $"RoutesID={RoutesList.Text} and " : "";

            string multiQuery = $"{licensePlate+ busNumber+ sumSeats+status+ busType + routes}";
            if (multiQuery != "")
            {
                int lastPs = multiQuery.LastIndexOf("and");
                multiQuery = multiQuery.Substring(0, lastPs);
                multiQuery = "where " + multiQuery;
            }
            return multiQuery;
        }

        private void LoadPhanTrang()
        {
            try
            {
                int TotalRows = int.Parse(this.hTotalRows.Value);
                int count = TotalRows / PageSize;
                if (TotalRows % PageSize > 0)
                    count++;
                if (count > 20)
                    count = 20;
                this.pnButton.Controls.Clear();
                for (int i = 0; i < count; i++)
                {
                    Button bt = new Button()
                    {
                        ID = "bt" + i,
                        Text = (i + 1).ToString()
                    };
                    bt.Attributes.Add("runat", "server");
                    bt.Click += new EventHandler(this.btPhanTrang_Click);
                    bt.CssClass = "btn btn-custome";

                    this.pnButton.Controls.Add(bt);
                }

            }
            catch { }
        }

        public void btPhanTrang_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int PageIndex = int.Parse(this.hPageIndex.Value);
            switch (btn.ID)
            {
                case "btTruoc":
                    PageIndex = int.Parse(this.hPageIndex.Value);
                    PageIndex = (PageIndex > 0) ? PageIndex - 1 : 0;
                    this.hPageIndex.Value = PageIndex.ToString();
                    break;
                case "btSau":
                    int TotalRows = int.Parse(hTotalRows.Value);
                    PageIndex = ((PageIndex + 1) * PageSize < TotalRows) ? PageIndex + 1 : PageIndex;
                    break;
                default:
                    PageIndex = int.Parse(btn.Text) - 1;
                    break;
            }
            this.hPageIndex.Value = PageIndex.ToString();
            pivot = PageIndex;
            LoadListBusPage(PageIndex);
        }

        public string Get_BusTypeName(int id)
        {
            return HRFunctions.Instance.GetBusTypeByID(id).Name;
        }

        public string Get_BusRouteName(int id)
        {
            return HRFunctions.Instance.GetBusRouteByID(id).RouteName;
        }
    }


}