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
    public partial class ResponsibleunitPage : System.Web.UI.Page
    {
        public List<ResponsibleUnit> ls = new List<ResponsibleUnit>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.hPageIndex.Value = "0";
                this.drlPageNumber.Text = Global.g_PageSize;
                LoadEdit();
                LoadResposible();
                this.LoadTimKiem(0);

            }
            LoadPhanTrang();
        }

        private void LoadResposible()
        {
            ls = HRFunctions.Instance.Select_All_ResponsibleUnit();
        }


        private ResponsibleUnit GetValue()
        {
            ResponsibleUnit obj = new ResponsibleUnit();
            obj.ResponsibleUnitID = this.txtID.Value.Length > 0 ? int.Parse(this.txtID.Value) : -1;
            obj.ReponsibleUnitName = this.txtResbonsilbeName.Value;
            int phone;
            int.TryParse(this.txtPhoneNumber.Value, out phone);
            obj.PhoneNumber = phone;
            return obj;
        }

        private void LoadEdit()
        {
            try
            {
                int idEdit = int.Parse(Request.QueryString["idedit"]);
                ResponsibleUnit obj = HRFunctions.Instance.Select_Responsible_Unit_ID(idEdit);
                if (obj != null)
                {
                    this.txtPhoneNumber.Value = obj.PhoneNumber.ToString();
                    this.txtID.Value = obj.ResponsibleUnitID.ToString();
                    this.txtResbonsilbeName.Value = obj.ReponsibleUnitName;
                }
            }
            catch { }
        }

        private void LoadPhanTrang()
        {
            try
            {
                int TotalRows = int.Parse(this.hTotalRows.Value);
                int PageSize = int.Parse(this.drlPageNumber.SelectedValue);
                int count = TotalRows / PageSize;
                if (TotalRows % PageSize > 0)
                    count++;
                if (count > 7)
                    count = 7;
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

        private void LoadTimKiem(int pIndex)
        {
            int PageSize = int.Parse(this.drlPageNumber.SelectedValue);
            int TotalRows = 0;
            this.ls = HRFunctions.Instance.ResponsibleUnit_Pagination(this.txtSearch.Value, PageSize, pIndex, out TotalRows);
            this.hTotalRows.Value = TotalRows.ToString();
            if (ls == null || ls.Count == 0)
            {
                this.pnTable.Visible = false;
            }
        }
        private bool Xet()
        {
            if (txtPhoneNumber.Value == "") return false;
            else if (txtResbonsilbeName.Value == "") return false;

            else return true;
        }

        protected void btLuu_Click1(object sender, EventArgs e)
        {
            
            if (Xet())
            {
                ResponsibleUnit obj = this.GetValue();
                HRFunctions.Instance.InsertNUpdateResponsible(obj);
                Clear();
                ShowAlert("swal('Success!','Cập nhật thông tin!','success')");
                LoadTimKiem(0);
            }
            else
            {
                ShowAlert("swal('Thông báo','Vui lòng nhập đầy đủ thông tin!','warning')");
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string selected = Request.Form["cbID"];
            if (selected != null && selected.Trim().Length > 0)
            {
                List<string> list = selected.Split(',').ToList();
                HRFunctions.Instance.DeleteResponsibleUnit(list);
                Response.Redirect(Request.RawUrl);
            }

        }

        protected void dlPageNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PageIndex = int.Parse(this.hPageIndex.Value);
            this.LoadTimKiem(PageIndex);
            Global.g_PageSize = this.drlPageNumber.SelectedValue;
        }

        private void Clear()
        {
            this.txtID.Value = "";
            this.txtResbonsilbeName.Value = "";
            this.txtPhoneNumber.Value = "";
        }


        protected void btTim_Click(object sender, EventArgs e)
        {
            this.hPageIndex.Value = "0";
            this.LoadTimKiem(0);
            this.LoadPhanTrang();
        }

        protected void btnClear_Click1(object sender, EventArgs e)
        {
            this.txtID.Value = "";
            this.txtResbonsilbeName.Value = "";
            this.txtPhoneNumber.Value = "";
        }
        private void ShowAlert(string note)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", note, true);
        }
    }
}   