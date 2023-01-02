using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.DBAccess;
using System.Drawing;
using System.Net;
using BusinessLayer.Functions;

namespace Web.Pages
{
    public partial class DocumentUI : System.Web.UI.Page
    {
        public List<Document> ls = new List<Document>();


        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsLogin)
            //  Response.Redirect("Login_Page.aspx");

            if (!Page.IsPostBack)
            {
                this.hPageIndex.Value = "0";
                this.dlPageNumber.Text = Global.g_PageSize;
                this.LoadTimKiem(0);
                this.LoadEditButton();
                this.LoadLinkButton();
                this.LoadProductType();
            }

            this.LoadPhanTrang();

        }

        private void LoadProductType()
        {
            this.drDocumentType.Items.Clear();
            this.drDocumentType.DataSource = HRFunctions.Instance.SelectAll_DocumentType();
            this.drDocumentType.DataTextField = "Name";
            this.drDocumentType.DataValueField = "DocumentTypeID";
            this.DataBind();

        }

        protected void btXoa_Click(object sender, EventArgs e)
        {
            string selected = Request.Form["cbID"];
            if (selected != null && selected.Trim().Length > 0)
            {
                List<string> list = selected.Split(',').ToList();
                HRFunctions.Instance.DeleteListDocumentType(list);
            }
            this.LoadTimKiem(int.Parse(this.hPageIndex.Value));

        }

        protected void btThemMoi_Click(object sender, EventArgs e)
        {
            this.pnControls.Visible = true;
            this.dlPageNumber.Visible = false;
            this.pnTable.Visible = false;
            this.pnPhanTrang.Visible = false;
            this.txtKeyword.Visible = false;
            this.btTim.Visible = false;
            this.btThemMoi.Visible = false;
            this.btXoa.Visible = false;
            this.Label1.Text = "";
            this.LbTitleh2.Text = "Thêm mới văn bản";
            this.txtID.Value = "";

            this.txtTitle.Value = "";
            this.txtContent.Value = "";


        }

        protected void btLuu_Click(object sender, EventArgs e)
        {
            if (txtTitle.Value != "")
            {
                if (FilePath.FileName != "")
                {
                    Document obj = this.GetValue();
                    if (this.FilePath.FileName != "")
                    {
                        this.FilePath.PostedFile.SaveAs(Server.MapPath(@"TaiLieu\") + obj.Path);
                    }
                    HRFunctions.Instance.InsertUpdate_Document(obj);

                    Label1.Text = "";
                    showMessage("Lưu thành công!");
                }
                else
                {
                    Label1.Text = "Lỗi! Bạn chưa chọn file văn bản.";
                }

            }
            else
            {
                Label1.Text = "Lỗi! Bạn chưa nhập tiêu đề văn bản!";
            }


        }

        private void showMessage(string mess)
        {
            string strBuilder = "<script language='javascript'>alert('" + mess + "')</script>";
            Response.Write(strBuilder);
        }


        private Document GetValue()
        {
            Document obj = new Document();
            obj.ID = this.txtID.Value.Length > 0 ? int.Parse(this.txtID.Value) : -1;
            obj.Title = this.txtTitle.Value;
            obj.Content = this.txtContent.Value;
            obj.Path = this.FilePath.FileName;
            obj.DocumentTypeID = int.Parse(this.drDocumentType.SelectedItem.Value);

            return obj;
        }

        protected void btImport_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    if (this.fuFileUpload.FileName.Length > 0)
            //    {
            //        string path = Server.MapPath("/ExcelFiles");
            //        this.fuFileUpload.SaveAs(path + "/xenoitinh.xlsx");
            //        List<NguoiDung> list = DataController.NguoiDung_ImportExcelFile(path + "/xenoitinh.xlsx");
            //        if (list != null && list.Count > 0)
            //        {
            //            DataController.NguoiDung_Import(list);
            //            this.Label1.Text = "Import thành công.";
            //        }
            //        else
            //            this.Label1.Text = "Danh sach rong.";
            //    }
            //}
            //catch { }

        }

        protected void btThoat_Click(object sender, EventArgs e)
        {
            this.pnControls.Visible = false;
            this.pnTable.Visible = true;
            this.pnPhanTrang.Visible = true;
            this.btXoa.Visible = true;
            this.btThemMoi.Visible = true;
            this.btTim.Visible = true;
            this.txtKeyword.Visible = true;
            this.dlPageNumber.Visible = true;
            this.Label1.Text = "";
            this.LoadTimKiem(int.Parse(this.hPageIndex.Value));
        }

        protected void btXoaTrang_Click(object sender, EventArgs e)
        {
            this.txtID.Value = "";

            this.txtTitle.Value = "";
            this.txtContent.Value = "";

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
        #endregion

        #region Methods

        private void LoadLinkButton()
        {
            try
            {
                int idLink = int.Parse(Request.QueryString["idLink"]);

                Document obj = HRFunctions.Instance.SelectDocumentId(idLink);


                if (obj != null)
                {
                    string path = @"TaiLieu\" + obj.Path;
                    string filePath = Server.MapPath(path);
                    WebClient User = new WebClient();
                    byte[] FileBuffer = User.DownloadData(filePath);

                    if (FileBuffer != null)
                    {
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);

                    }

                }


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
                this.pnControls.Visible = true;
                this.dlPageNumber.Visible = false;
                this.pnTable.Visible = false;
                this.pnPhanTrang.Visible = false;
                this.txtKeyword.Visible = false;
                this.btTim.Visible = false;
                this.btThemMoi.Visible = false;
                this.btXoa.Visible = false;
                this.Label1.Text = "";
                this.LbTitleh2.Text = "Sửa văn bản";
                Document obj = HRFunctions.Instance.EditDocumentUI_ByID(idEdit);
                if (obj != null)
                {
                    this.txtID.Value = obj.ID.ToString();

                    this.txtTitle.Value = obj.Title;
                    this.txtContent.Value = obj.Content;
                    this.drDocumentType.SelectedValue = obj.DocumentTypeID.ToString();

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
                    bt.BackColor = Color.FromArgb(64, 180, 124);
                    bt.ForeColor = Color.White;
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
            this.ls = HRFunctions.Instance.FindDocumentByKeyWord(this.txtKeyword.Value, PageSize, pIndex, out TotalRows);
            this.hTotalRows.Value = TotalRows.ToString();
            if (ls == null || ls.Count == 0)
            {
                this.pnTable.Visible = false;
                this.pnPhanTrang.Visible = false;
                this.Label1.Text = "Không tìm thấy dữ liệu.";
            }
        }
        #endregion
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void hPageIndex_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}