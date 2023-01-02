using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentLayer;
using DocumentLayer.MasterSystem;

namespace DocumentWebDemo.pages
{
    public partial class ClientUI : System.Web.UI.Page
    {
        public List<Document> ls = new List<Document>();
        private string loai = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DdrDocumentType.AutoPostBack = true;
            this.DdrView.AutoPostBack = true;
            this.Label2.Text = "Chọn thể loại:";

            if (!Page.IsPostBack)
            {

                this.hPageIndex.Value = "0";
                this.dlPageNumber.Text = Global.g_PageSize;
                LoadLinkButton();

            }

            this.LoadDdrView();
            this.LoadPhanTrang();


        }

        private void LoadLinkButton()
        {
            try
            {
                int idLink = int.Parse(Request.QueryString["idLink"]);

                Document obj = DocumentManagement.Instance.documentFunc.Select_ID(idLink);


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
        private void LoadDdrView()
        {
            if (this.DdrView.SelectedItem.Value == "Xem tất cả văn bản")
            {
                LoadAllDocument(0);
                this.DdrDocumentType.Visible = false;
                this.Label2.Visible = false;
            }
           
        }


        private void LoadAllDocument(int pIndex)
        {
            int PageSize = int.Parse(this.dlPageNumber.SelectedValue);
            int TotalRows = 0;
            this.ls = DocumentManagement.Instance.documentFunc.Find_DocumentAll(PageSize,pIndex,out TotalRows);
            this.hTotalRows.Value = TotalRows.ToString();
          
        }
        private void LoadThLoai(int pIndex)
        {
            int PageSize = int.Parse(this.dlPageNumber.SelectedValue);
            int TotalRows = 0;
            this.ls = DocumentManagement.Instance.documentFunc.Find_DocumentType(loai,PageSize,pIndex,out TotalRows);
            this.hTotalRows.Value = TotalRows.ToString();
        
        }

        private void LoadProductType()
        {
            this.DdrDocumentType.Items.Clear();
            this.DdrDocumentType.DataSource = DocumentManagement.Instance.typeFunc.Select_All();
            this.DdrDocumentType.DataTextField = "Name";
            this.DdrDocumentType.DataValueField = "DocumentTypeID";
            this.DataBind();

        }

        protected void dlPageNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PageIndex = int.Parse(this.hPageIndex.Value);
            if (this.DdrView.SelectedItem.Value == "Xem tất cả văn bản")
            {
                LoadAllDocument(PageIndex);
                this.DdrDocumentType.Visible = false;
                this.Label2.Visible = false;
            }
            else
            {

                this.DdrDocumentType.Visible = true;
                this.Label2.Visible = true;


                LoadProductType();
                loai = this.DdrDocumentType.SelectedValue;
                LoadThLoai(PageIndex);
            }
         
            Global.g_PageSize = this.dlPageNumber.SelectedValue;
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
            if (this.DdrView.SelectedItem.Value == "Xem tất cả văn bản")
            {
                LoadAllDocument(PageIndex);

            }
            

            if(this.DdrView.SelectedItem.Value == "Xem văn bản theo thể loại")
            {
                loai = this.DdrDocumentType.SelectedValue;
                LoadThLoai(PageIndex);
            }
            this.UpdatePanel1.Update();
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
      

        protected void DdrDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loai = DdrDocumentType.SelectedValue;
            LoadThLoai(0);
            this.LoadPhanTrang();
        }

        protected void DdrView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdrView.SelectedItem.Value == "Xem văn bản theo thể loại")
            {
                this.DdrDocumentType.Visible = true;
                this.Label2.Visible = true;


                LoadProductType();
                loai = this.DdrDocumentType.SelectedValue;
         
                
                LoadThLoai(0);
                this.LoadPhanTrang();
            }
            else
            {
                LoadDdrView();
            }
        }
    }
}