using BusinessLayer;
using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //List<int> list = new List<int> { 1, 2, 3, 4, 5 };
        int PageSize = int.Parse(Global.g_PageSize2);
        public int pivot = 0;
        //int PageSize = 2;

        public List<Bus> listBus;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hPageIndex.Value = "0";
                LoadDropDownList();
            }
            LoadListBusPage(0);
            if (!IsPostBack)
            {
                LoadEditButton();
            }
        }

        protected void AddBusButton_Click(object sender, EventArgs e)
        {
            if (!CheckNull())
            {
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Warning!','Bạn không được để trống !!!','warning')", true);
                //Response.Write("<script>alert('Bạn không được để trống các ô')</script>");
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bạn không được để trống các ô')", true);
                ShowAlert("swal('Warning!','Bạn không được để trống các ô !!!','warning')");
            }
            else if (HRFunctions.Instance.FindBusByBienSoXe(this.BienSoXe.Value) != null)
            {
                ShowAlert("swal('Error!','Biển số xe đã tồn tại!','error')");
            }
            else if (HRFunctions.Instance.FindBusByBusNumber(this.SoXe.Value) != null)
            {
                ShowAlert("swal('Error!','Số của xe đã tồn tại!','error')");

            }
            else
            {
                Bus bus = new Bus
                {
                    LicensePlates = this.BienSoXe.Value,
                    BusNumber = this.SoXe.Value,
                    SumSeats = int.Parse(this.SoChoNgoi.Value),
                    Status = this.TrangThai.Value,
                    BusTypeID = int.Parse(this.bustypelist.Text),
                    RoutesID = int.Parse(this.tuyenlist.Text),
                };
                HRFunctions.Instance.AddBus(bus);
                ShowAlert("swal('Success!','Thêm xe thành công!','success')");
                ClearInput();
                LoadDropDownList();

            }

            LoadListBusPage(0, false);
        }


        protected bool CheckNull()
        {
            if (string.IsNullOrWhiteSpace(this.BienSoXe.Value) || string.IsNullOrWhiteSpace(this.SoXe.Value) ||
                string.IsNullOrWhiteSpace(this.SoChoNgoi.Value) || string.IsNullOrWhiteSpace(this.TrangThai.Value) ||
                this.bustypelist.Text == "Tất cả" || this.tuyenlist.Text == "Tất cả")
            {
                return false;
            }
            return true;
        }

        protected void ClearInput()
        {
            this.BusID.Value = "";
            this.BienSoXe.Value = "";
            this.SoXe.Value = "";
            this.SoChoNgoi.Value = "";
            this.TrangThai.Value = "";
            this.bustypelist.SelectedIndex = 0;
            this.tuyenlist.SelectedIndex = 0;
        }

        private void LoadEditButton()
        {
            try
            {
                int idEdit = int.Parse(Request.QueryString["idedit"]);
                Bus bus = HRFunctions.Instance.FindBusByID(idEdit);
                if (bus != null)
                {
                    this.BusID.Value = bus.BusID.ToString();
                    this.BienSoXe.Value = bus.LicensePlates;
                    this.SoXe.Value = bus.BusNumber;
                    this.SoChoNgoi.Value = bus.SumSeats.ToString();
                    this.TrangThai.Value = bus.Status;

                    BusType busType = HRFunctions.Instance.FindBusTypeByID(bus.BusTypeID);

                    this.bustypelist.SelectedValue = busType.BusTypeID.ToString();
                    this.tuyenlist.Text = bus.RoutesID.ToString();
                    pivot = int.Parse(Request.QueryString["page"]);
                    //LoadListBusPage(0);
                    LoadListBusPage(pivot,false);
                }
            }
            catch { }
        }

        protected void UpdateBusButton_Click(object sender, EventArgs e)
        {
            if (!CheckNull())
            {
                ShowAlert("swal('Warning!','Bạn không được để trống các ô !!!','warning')");
            }
            else if (HRFunctions.Instance.FindBusByBienSoXe(this.BienSoXe.Value) == null ||
                HRFunctions.Instance.FindBusByID(int.Parse(this.BusID.Value)).LicensePlates == this.BienSoXe.Value
                )
            {
                if (string.IsNullOrWhiteSpace(this.BusID.Value))
                {
                    ShowAlert("swal('Warning!','Chưa chọn xe để cập nhật!!!','warning')");
                }
                else
                {
                    var test = HRFunctions.Instance.FindBusByBusNumber(this.SoXe.Value);
                    if (test == null || test.BusID == int.Parse(this.BusID.Value))
                    {
                        Bus bus = HRFunctions.Instance.FindBusByID(int.Parse(this.BusID.Value));

                        bus.LicensePlates = this.BienSoXe.Value;
                        bus.BusNumber = this.SoXe.Value;
                        bus.SumSeats = int.Parse(this.SoChoNgoi.Value);
                        bus.Status = this.TrangThai.Value;
                        bus.BusTypeID = int.Parse(this.bustypelist.Text);
                        bus.RoutesID = int.Parse(this.tuyenlist.Text);

                        HRFunctions.Instance.AddBus(bus);
                        ShowAlert("swal('Success!','Cập nhật xe thành công!','success')");
                        //Them do
                        ClearInput();
                    }
                    else
                    {
                        ShowAlert("swal('Error!','Số của xe đã tồn tại','error')");
                    }
                }
            }
            else
            {
                ShowAlert($"swal('Error!','Biển số xe {this.BienSoXe.Value} đã tồn tại!','error')");
                this.BienSoXe.Value = "";
                //LoadListBusPage(0);
            }
            try
            {
                pivot = int.Parse(Request.QueryString["page"]);
            }
            catch
            {
                pivot = 0;
            }
            PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            isreadonly.SetValue(this.Request.QueryString, false, null);
            Request.QueryString.Clear();
            LoadListBusPage(pivot, false);
        }

        private void ShowAlert(string note)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", note, true);
        }

        protected void LoadDropDownList()
        {
            this.bustypelist.DataSource = HRFunctions.Instance.SelectAllBusType();
            this.bustypelist.DataTextField = "Name";
            this.bustypelist.DataValueField = "BusTypeID";
            this.bustypelist.DataBind();
            this.bustypelist.Items.Insert(0, "Tất cả");
            this.bustypelist.SelectedIndex = 0;

            this.tuyenlist.DataSource = HRFunctions.Instance.SelectAllBusRoutes();
            this.tuyenlist.DataTextField = "RouteName";
            this.tuyenlist.DataValueField = "BusRouteID";
            this.tuyenlist.DataBind();
            this.tuyenlist.Items.Insert(0, "Tất cả");
            this.tuyenlist.SelectedIndex = 0;

            //this.BusList.DataSource = HRFunctions.Instance.SelectAllBus();
            //this.BusList.DataTextField = "BusID";
            //this.BusList.DataValueField = "BusID";
            //this.BusList.DataBind();
            //this.BusList.Items.Insert(0, "ID xe");
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

        private void LoadListBusPage(int pIndex, bool isSearch=true)
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

        protected void DeleteBusButton_CLick(object sender, EventArgs e)
        {
            string selected = Request.Form["cbID"];
            if (selected != null && selected.Trim().Length > 0)
            {
                List<string> list = selected.Split(',').ToList();
                HRFunctions.Instance.DeleteBusByIDs(list);
                ShowAlert("swal('Success!','Xóa xe thành công!','success')");
            }
            LoadListBusPage(0);
            LoadDropDownList();
            //LoadPhanTrang();
            ClearInput();
        }

        protected string SearchByCriteria()
        {
            string licensePlate = !BienSoXe.Value.IsNullOrWhiteSpace() ? $"LicensePlates='{BienSoXe.Value}' and " : "";
            string busNumber = !SoXe.Value.IsNullOrWhiteSpace() ? $"BusNumber='{SoXe.Value}' and " : "";
            string sumSeats = !SoChoNgoi.Value.IsNullOrWhiteSpace() ? $"SumSeats='{SoChoNgoi.Value}' and " : "";
            string status = !TrangThai.Value.IsNullOrWhiteSpace() ? $"Status=N'{TrangThai.Value}' and " : "";
            string busType = bustypelist.Text != "Tất cả" ? $"BusTypeID={int.Parse(this.bustypelist.Text)} and " : "";
            string routes = tuyenlist.Text != "Tất cả" ? $"RoutesID={tuyenlist.Text} and " : "";

            string multiQuery = $"{licensePlate + busNumber + sumSeats + busType + status + routes}";
            if (multiQuery != "")
            {
                int lastPs = multiQuery.LastIndexOf("and");
                multiQuery = multiQuery.Substring(0, lastPs);
                multiQuery = "where " + multiQuery;
            }
            return multiQuery;
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            LoadListBusPage(0);
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadListBusPage(0);
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