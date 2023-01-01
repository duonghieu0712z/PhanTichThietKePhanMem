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
    public partial class DriverPage : System.Web.UI.Page
    {
        public List<Driver> ls = new List<Driver>();
        public Driver_Bus ls1 = new Driver_Bus();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.hPageIndex.Value = "0";
                this.dlPageNumber.Text = Global.g_PageSize;
                this.LoadTimKiem(0);
                this.LoadEditButton();
                LoadResponsibleUnit();
            }
            this.LoadPhanTrang();
        }

        private void LoadResponsibleUnit()
        {
            this.drDriverBus.Items.Clear();
            this.drDriverBus.DataSource = HRFunctions.Instance.SelectAllBus();
            this.drDriverBus.DataTextField = "BusNumber";
            this.drDriverBus.DataValueField = "BusID";
            this.DataBind();
        }

        protected void btXoa_Click(object sender, EventArgs e)
        {
            string selected = Request.Form["cbID"];
            if (selected != null && selected.Trim().Length > 0)
            {
                List<string> list = selected.Split(',').ToList();
                HRFunctions.Instance.Delete_IDs_Driver(list);
                ShowAlert("swal('Success!','Xóa thành công!','success')");
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
            this.lablebus.Visible = false;
            this.drDriverBus.Visible = false;
        }

        protected void btLuu_Click(object sender, EventArgs e)
        {
            Driver obj = this.GetValue();

            HRFunctions.Instance.InsertNUpdateDriver(obj);

            this.pnTable.Visible = true;
            this.pnControls.Visible = false;

            ShowAlert("swal('Success!','Cập nhật thông tin!','success')");
            this.LoadTimKiem(0);
        }

        private Driver GetValue()
        {
            Driver obj = new Driver();
            obj.DriverID = this.txtID.Value.Length > 0 ? int.Parse(this.txtID.Value) : -1;
            obj.FullName = this.txtName.Value;
            obj.IDCard = this.txtIDCard.Value;
            obj.DayOfBirth = DateTime.Parse(this.txtDayOfBirth.Value);
            obj.Sex = (drSex.Text == "Nam") ? true : false;
            obj.HomeTown = this.txtHomeTown.Value;
            //  obj.ID = int.Parse(this.drDriverBus.SelectedValue);
            Console.WriteLine(obj);
            return obj;
        }

        private Driver_Bus GetBusOfDriver()
        {
            Driver_Bus obj = new Driver_Bus();
            obj.BusID = int.Parse(this.drDriverBus.SelectedValue);
            obj.DriverID = int.Parse(this.txtID.Value);
            obj.DepartureDay = DateTime.Now;
            return obj;
        }

        protected void btThoat_Click(object sender, EventArgs e)
        {
            this.pnControls.Visible = false;
            this.pnTable.Visible = true;
            this.pnPhanTrang.Visible = true;
            this.Label1.Text = "";
            this.LoadTimKiem(int.Parse(this.hPageIndex.Value));
        }

        protected void btXoaTrang_Click(object sender, EventArgs e)
        {
            this.txtID.Value = "";
            this.txtIDCard.Value = "";
            this.txtName.Value = "";
            this.drSex.SelectedIndex = 0;
            this.txtDayOfBirth.Value = "";
            this.txtHomeTown.Value = "";

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

        #region Methods

        private void LoadEditButton()
        {
            try
            {
                int idEdit = int.Parse(Request.QueryString["idedit"]);
                this.pnTable.Visible = false;
                this.pnPhanTrang.Visible = false;
                this.pnControls.Visible = true;
                this.lablebus.Visible = true;
                this.drDriverBus.Visible = true;
                Driver obj = HRFunctions.Instance.Select_Driver_ID(idEdit);
                if (obj != null)

                {
                    this.txtID.Value = obj.DriverID.ToString();
                    this.txtIDCard.Value = obj.IDCard.ToString();
                    this.txtName.Value = obj.FullName;
                    this.txtDayOfBirth.Value = obj.DayOfBirth.ToString("mm-dd-yyyy");
                    this.txtHomeTown.Value = obj.HomeTown.ToString();
                    if (obj.Sex == true)
                    {
                        this.drSex.SelectedValue = "Nam";
                    }
                    else
                    {
                        this.drSex.SelectedValue = "Nữ";
                    }
                }
            }
            catch { }

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
        private void LoadTimKiem(int pIndex)
        {
            int PageSize = int.Parse(this.dlPageNumber.SelectedValue);
            int TotalRows = 0;
            this.ls = HRFunctions.Instance.Driver_Pagination(this.txtKeyword.Value, PageSize, pIndex, out TotalRows);
            this.hTotalRows.Value = TotalRows.ToString();
            if (ls == null || ls.Count == 0)
            {
                this.pnTable.Visible = false;
                this.pnPhanTrang.Visible = false;
                this.Label1.Text = "Không tìm thấy dữ liệu.";
            }
        }


        private void ShowAlert(string note)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", note, true);
        }

        public string Sex(bool s)
        {
            return s == true ? "Nam" : "Nữ";
        }
        #endregion

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Driver_Bus driver_Bus = this.GetBusOfDriver();
            HRFunctions.Instance.InsertNUpdateDriverOfBus(driver_Bus);

            ShowAlert("swal('Success!','Cập nhật thông tin!','success')");
            this.LoadTimKiem(0);
        }
    }
}