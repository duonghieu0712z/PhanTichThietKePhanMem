using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentLayer;
using DocumentLayer.MasterSystem;

namespace DocumentWebDemo.pages
{
    public partial class PostPage : System.Web.UI.Page
    {
        public List<POST> ls = new List<POST>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.hPageIndex.Value = "0";
                this.dlPageNumber.Text = Global.g_PageSize;
                LoadEditButton();
                LoadTimKiem(0);
                LoadPhanTrang();
            }
            LoadBusPOST();
            Page.Title = "Quản lý bài viết";
        }

        private void LoadBusPOST()
        {
            ls = DocumentManagement.Instance.postFunc.POST_Select_All();
        }

        private POST getInputValue()
        {
            POST obj = new POST();
            obj.ID = this.txtID.Value.Length > 0 ? int.Parse(this.txtID.Value) : -1;
            obj.Title = this.txtPostName.Value;
            obj.NgayDang = DateTime.Now;
            obj.Content = this.txtContent.Value;
            obj.SummaryContent = this.txtSummaryContent.Value;
            obj.Link = this.txtLinkImage.Value;
            return obj;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            POST obj = this.getInputValue();
            DocumentManagement.Instance.postFunc.POST_InsertUpdate(obj);
            ClearText();
            Response.Redirect(Request.RawUrl);
        }

        public void ClearText()
        {
            try
            {
                this.txtID.Value = "";
                this.txtDateCreated.Value = "";
                this.txtPostName.Value = "";
                this.txtContent.Value = "";
                this.txtSummaryContent.Value = "";
                this.txtLinkImage.Value = "";
            }
            catch
            {

            }
        }

        private void LoadEditButton()
        {
            try
            {
                int idEdit = int.Parse(Request.QueryString["idedit"]);
                POST obj = DocumentManagement.Instance.postFunc.POST_Select_ID(idEdit);
                if (obj != null)
                {

                    this.txtID.Value = obj.ID.ToString();
                    this.txtPostName.Value = obj.Title;
                    this.txtSummaryContent.Value = obj.SummaryContent;
                    this.txtDateCreated.Value = obj.NgayDang.ToString();
                    this.txtLinkImage.Value = obj.Link.ToString();
                    this.txtContent.Value = obj.Content;
                }
            }
            catch { }
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            string selected = Request.Form["cbID"];
            if (selected != null && selected.Trim().Length > 0)
            {
                List<string> list = selected.Split(',').ToList();
                DocumentManagement.Instance.postFunc.POST_Delete_IDs(list);
                Response.Redirect(Request.RawUrl);
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

        private void LoadTimKiem(int pIndex)
        {
            int PageSize = int.Parse(this.dlPageNumber.SelectedValue);
            int TotalRows = 0;

            this.ls = DocumentManagement.Instance.postFunc.POST_Find_KeyWord(this.txtKeyword.Value, PageSize, pIndex, out TotalRows);
            this.hTotalRows.Value = TotalRows.ToString();
            if (ls == null || ls.Count == 0)
            {
                this.pnTable.Visible = false;
                this.pnPhanTrang.Visible = false;
            }

        }

        protected void dlPageNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PageIndex = int.Parse(this.hPageIndex.Value);
            this.LoadTimKiem(PageIndex);
            LoadPhanTrang();
            Global.g_PageSize = this.dlPageNumber.SelectedValue;
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            this.pnPhanTrang.Visible = true;
            this.hPageIndex.Value = "0";
            this.LoadTimKiem(0);
            this.LoadPhanTrang();
            this.txtKeyword.Value = "";
        }
    }


}