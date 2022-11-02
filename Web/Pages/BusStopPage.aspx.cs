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
    public partial class BusStopPage : System.Web.UI.Page
    {
        public List<BusStop> ls = new List<BusStop>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.hPageIndex.Value = "0";
                this.dlPageNumber.Text = Global.g_PageSize;
                this.LoadTimKiem(0);
                this.LoadEditButton();

            }
            this.LoadPhanTrang();

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
                    int PageSize = int.Parse(this.dlPageNumber.SelectedValue);
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
        protected void dlPageNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PageIndex = int.Parse(this.hPageIndex.Value);
            this.LoadTimKiem(PageIndex);
            Global.g_PageSize = this.dlPageNumber.SelectedValue;

        }
        protected void btXoa_Click(object sender, EventArgs e)
        {
            string selected = Request.Form["cbID"];
            if (selected != null && selected.Trim().Length > 0)
            {
                List<string> list = selected.Split(',').ToList();
                HRFunctions.Instance.DeleteBusStopByIDs(list);

                ShowAlert("swal('Success!','Xóa thành công!','success')");

                this.Clear();


            }
            else
            {
                ShowAlert("swal('Error!','Đã xãy ra lỗi!','error')");
            }
            this.LoadTimKiem(int.Parse(this.hPageIndex.Value));


        }

        protected void btThemMoi_Click(object sender, EventArgs e)
        {
            this.pnControls.Visible = true;
            this.pnTable.Visible = false;
            this.pnPhanTrang.Visible = false;
            this.Label1.Text = "";

        }

        protected void btLuu_Click(object sender, EventArgs e)
        {
            if (Xet())
            {
                BusStop bs = this.GetValue();
                HRFunctions.Instance.InsertBusStop(bs);
                this.pnTable.Visible = true;
                this.pnControls.Visible = false;
                ShowAlert("swal('Success!','Cập nhật thông tin!','success')");
                this.LoadTimKiem(int.Parse(this.hPageIndex.Value));


            }
            else
            {
                this.Label1.Text = "Vui lòng nhập đầy đủ thông tin";
            }



        }
        protected void btTim_Click(object sender, EventArgs e)
        {
            this.pnControls.Visible = false;
            this.pnTable.Visible = true;
            this.pnPhanTrang.Visible = true;
            this.Label1.Text = "";

            this.hPageIndex.Value = "0";
            this.LoadTimKiem(0);
            this.LoadPhanTrang();

        }
        protected void btXoaTrang_Click(object sender, EventArgs e)
        {
            this.Clear();


        }
        protected void btImport_Click(object sender, EventArgs e)
        {

        }

        protected void btThoat_Click(object sender, EventArgs e)
        {

        }

        #region Methods
        private void LoadBusTop()
        {
            ls = HRFunctions.Instance.SelectAllBusStop();
        }
        private void Clear()
        {
            this.txtDescription.Value = "";
            this.txtDistrict.Value = "";
            this.txtLatitude.Value = "";
            this.txtLongitude.Value = "";
            this.txtName.Value = "";
            this.txtWard.Value = "";
            this.txtStreet.Value = "";
        }
        private BusStop GetValue()
        {
            BusStop bs = new BusStop();
            bs.BusStopID = this.txtID.Value.Length > 0 ? int.Parse(this.txtID.Value) : -1;
            bs.BusStopName = this.txtName.Value;
            bs.Wards = this.txtWard.Value;
            bs.Street = this.txtStreet.Value;
            bs.District = this.txtDistrict.Value;
            bs.Longitude = double.Parse(this.txtLongitude.Value);
            bs.Latitude = double.Parse(this.txtLatitude.Value);
            bs.BusStopDescription = this.txtDescription.Value;
            return bs;
        }
        private bool Xet()
        {
            if (txtName.Value == "") return false;
            else if (txtLatitude.Value == "") return false;
            else if (txtLongitude.Value == "") return false;
            else if (txtDistrict.Value == "") return false;
            else if (txtWard.Value == "") return false;
            else if (txtStreet.Value == "") return false;
            else return true;
        }

        private void LoadEditButton()
        {
            try
            {
                int idEdit = int.Parse(Request.QueryString["idedit"]);
                this.pnTable.Visible = false;
                //  this.pnPhanTrang.Visible = false;
                this.pnControls.Visible = true;
                BusStop obj = HRFunctions.Instance.FindBusStopByID(idEdit);
                if (obj != null)
                {
                    this.txtID.Value = obj.BusStopID.ToString();
                    this.txtName.Value = obj.BusStopName;
                    this.txtLongitude.Value = obj.Longitude.ToString();
                    this.txtLatitude.Value = obj.Latitude.ToString();
                    this.txtStreet.Value = obj.Street;
                    this.txtWard.Value = obj.Wards;
                    this.txtDistrict.Value = obj.District;
                    this.txtDescription.Value = obj.BusStopDescription;

                }
            }
            catch { }

        }
        private void LoadTimKiem(int pIndex)
        {
            int PageSize = int.Parse(this.dlPageNumber.SelectedValue);
            int TotalRows = 0;

            this.ls = HRFunctions.Instance.Bus_Stop_Pagination(PageSize, pIndex, out TotalRows);
            this.hTotalRows.Value = TotalRows.ToString();
            if (ls == null || ls.Count == 0)
            {
                this.pnTable.Visible = false;
                this.pnPhanTrang.Visible = false;
                this.Label1.Text = "Không tìm thấy dữ liệu.";
            }

        }
        private void LoadPhanTrang()
        {
            try
            {
                int TotalRows = int.Parse(this.hTotalRows.Value);
                int PageSize = int.Parse(this.dlPageNumber.SelectedValue);
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
                    bt.CssClass = "btn btn-dark";
                    this.pnButton.Controls.Add(bt);

                }

            }
            catch { }
        }
        private void ShowAlert(string note)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", note, true);
        }

        #endregion
    }
}