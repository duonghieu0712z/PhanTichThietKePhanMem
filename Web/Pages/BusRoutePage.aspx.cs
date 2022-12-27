using BusinessLayer.DBAccess;
using BusinessLayer.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Web.Pages
{
    public partial class BusRoutePage : System.Web.UI.Page
    {
        public List<BusRoute> ls = new List<BusRoute>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.hPageIndex.Value = "0";
                this.drlPageNumber.Text = Global.g_PageSize;
                this.LoadTimKiem(0);
                this.LoadResponsibleUnit();
            }
            this.LoadBusRoute();
            this.LoadEditButton();
            this.LoadPhanTrang();
        }

        private void LoadBusRoute()
        {
            ls = HRFunctions.Instance.SelectAllBusRoute();
        }

        private void LoadResponsibleUnit()
        {
            this.ddlResponsibleUnit.Items.Clear();
            this.ddlResponsibleUnit.DataSource = HRFunctions.Instance.Select_All_ResponsibleUnit();
            this.ddlResponsibleUnit.DataTextField = "ReponsibleUnitName";
            this.ddlResponsibleUnit.DataValueField = "ResponsibleUnitID";
            this.DataBind();
        }

        private void LoadEditButton()
        {
            this.pnPhanTrang.Visible = true;
            try
            {
                int idEdit = int.Parse(Request.QueryString["idEdit"]);
                BusRoute obj = HRFunctions.Instance.Select_Bus_Route_ID(idEdit);
                if (obj != null)
                {
                    this.txtID.Value = obj.BusRouteID.ToString();
                    this.txtRouteName.Value = obj.RouteName;
                    this.txtRouteNumber.Value = obj.RouteNumber;
                    this.ddlResponsibleUnit.SelectedValue = obj.ResponsibleUnitID.ToString();
                    this.txtOperationType.Value = obj.OperationType;
                    this.txtOperationTime.Value = obj.OperationTime.ToString();
                    this.txtFare.Value = obj.Fare.ToString();
                    this.txtBusesAmount.Value = obj.BusesAmount.ToString();
                    this.txtBusesTime.Value = obj.BusesTime.ToString();
                    this.txtBusesSpace.Value = obj.BusesSpace.ToString();
                }
            }
            catch { }
        }

        private bool Xet()
        {
            if (txtRouteName.Value == "") return false;
            else if (txtRouteNumber.Value == "") return false;
            else if (txtOperationTime.Value == "") return false;
            else if (txtOperationType.Value == "") return false;
            else if (txtFare.Value == "") return false;
            else if (txtBusesAmount.Value == "") return false;
            else if (txtBusesSpace.Value == "") return false;
            else if (txtBusesTime.Value == "") return false;

            else return true;
        }

        protected void btTim_Click(object sender, EventArgs e)
        {
            this.pnPhanTrang.Visible = true;
            this.Label1.Text = "";
            this.hPageIndex.Value = "0";
            this.LoadTimKiem(0);
            this.LoadPhanTrang();
        }

        private void LoadTimKiem(int pIndex)
        {
            int PageSize = int.Parse(this.drlPageNumber.SelectedValue);
            int TotalRows = 0;
            this.ls = HRFunctions.Instance.Bus_Route_Pagination(this.txtKeyword.Value, PageSize, pIndex, out TotalRows);
            this.hTotalRows.Value = TotalRows.ToString();
            if (ls == null || ls.Count == 0)
            {
                this.pnTable.Visible = false;
                this.pnPhanTrang.Visible = false;
                this.Label1.Text = "Không tìm thấy dữ liệu";
            }
        }

        private void LoadPhanTrang()
        {
            try
            {
                int TotalRows = int.Parse(this.hTotalRows.Value);
                int PageSize = int.Parse(Global.g_PageSize);
                int count = TotalRows / PageSize;
                if (TotalRows % PageSize > 0)
                    count++;
                if (count > 5)
                    count = 5;
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
                    bt.CssClass = "btn btn-dark ml-2";
                    this.pnButton.Controls.Add(bt);
                }

            }
            catch { }
        }

        protected void btPhanTrang_Click(object sender, EventArgs e)
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
                    int PageSize = int.Parse(this.drlPageNumber.SelectedValue);
                    int TotalRows = int.Parse(hTotalRows.Value);
                    PageIndex = ((PageIndex + 1) * PageSize < TotalRows) ? PageIndex + 1 : PageIndex;
                    break;
                default:
                    PageIndex = int.Parse(btn.Text) - 1;
                    break;
            }
            this.hPageIndex.Value = PageIndex.ToString();
            this.LoadTimKiem(PageIndex);
            this.UpdatePanel1.Update();
        }

        protected void drlPageNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PageIndex = int.Parse(this.hPageIndex.Value);
            this.LoadTimKiem(PageIndex);
            Global.g_PageSize = this.drlPageNumber.SelectedValue;
        }

        protected void btXoa_Click(object sender, EventArgs e)
        {
            string selected = Request.Form["cbID"];
            if (selected != null && selected.Trim().Length > 0)
            {
                List<string> list = selected.Split(',').ToList();
                HRFunctions.Instance.DeleteBusRouteByIDs(list);
            }
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
            Response.Redirect(Request.RawUrl);
        }

        private BusRoute GetValue()
        {
            BusRoute obj = new BusRoute();
            obj.BusRouteID = this.txtID.Value.Length > 0 ? int.Parse(this.txtID.Value) : -1;
            obj.RouteName = this.txtRouteName.Value;
            obj.OperationType = this.txtOperationType.Value;
            obj.OperationTime = this.txtOperationTime.Value;
            obj.Fare = int.Parse(this.txtFare.Value);
            obj.RouteNumber = this.txtRouteNumber.Value;
            obj.BusesTime = this.txtBusesTime.Value;
            obj.BusesAmount = this.txtBusesAmount.Value;
            obj.BusesSpace = this.txtBusesSpace.Value;
            return obj;
        }

        private void Clear()
        {
            this.txtID.Value = "";
            this.txtRouteNumber.Value = "";
            this.txtRouteName.Value = "";
            this.txtOperationType.Value = "";
            this.txtOperationTime.Value = "";
            this.txtFare.Value = "";
            this.txtBusesSpace.Value = "";
            this.txtBusesTime.Value = "";
            this.txtBusesAmount.Value = "";
        }

        protected void btLuu_Click(object sender, EventArgs e)
        {
            if (Xet())
            {
                ShowAlert("swal('Success!','Cập nhật thông tin!','success')");
                BusRoute obj = this.GetValue();
                HRFunctions.Instance.InsertNUpdateBusRoute(obj);
                Clear();
                Response.Redirect(Request.RawUrl);
                LoadTimKiem(0);
            }
            else
            {
                this.error.Text = "Vui lòng nhập đầy đủ thông tin";
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void ShowAlert(string note)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", note, true);
        }
    }
}