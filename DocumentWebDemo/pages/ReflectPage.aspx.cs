using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentLayer;
using DocumentLayer.MasterSystem;
using System.Reflection;

namespace DocumentWebDemo.pages
{
    public partial class ReflectPage : System.Web.UI.Page
    {
        int PageSize = 5;
        public int pivot = 0;


        public List<ReflectType> reflectTypes;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadListBusType();
            if (!IsPostBack)
            {
                this.hPageIndex.Value = "0";
                LoadListBusTypePage(0);
                LoadEditButton();
            }
            LoadPhanTrang();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TenLoai.Value))
            {
                ShowAlert("swal('Warning!','Chưa nhập đủ thông tin!','warning')");
            }
            else
            {
                if (DocumentManagement.Instance.reflectTypeFunc.ReflectType_Select_ReflectTypeName(this.TenLoai.Value) == null)
                {
                    ReflectType reflectType;
                    reflectType = new ReflectType
                    {
                        ReflectTypeID = 0,
                        Name = TenLoai.Value,

                    };
                    int id = DocumentManagement.Instance.reflectTypeFunc.ReflectType_InsertUpdate(reflectType);
                    //LoadListBusType(
                    //LoadListBusTypePage(0);
                    ShowAlert("swal('Success!','Thêm loại xe thành công!','success')");
                    ClearAll();
                }
                else
                {
                    ShowAlert("swal('Error!','Tên loại và hãng xe đã tồn tại!','error')");
                }

            }
            LoadListBusTypePage(0);
            LoadPhanTrang();
        }

        private void LoadListBusType()
        {
            reflectTypes = DocumentManagement.Instance.reflectTypeFunc.ReflectType_Select_All();
        }

        private void LoadEditButton()
        {
            try
            {
                int idEdit = int.Parse(Request.QueryString["idedit"]);
                ReflectType busType = DocumentManagement.Instance.reflectTypeFunc.ReflectType_Select_ID(idEdit);
                if (busType != null)
                {
                    this.IDLoaiPhanAnh.Value = busType.ReflectTypeID.ToString();
                    this.TenLoai.Value = busType.Name;
                    pivot = int.Parse(Request.QueryString["page"]);
                    LoadListBusTypePage(pivot);
                }
            }
            catch { }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IDLoaiPhanAnh.Value) || string.IsNullOrWhiteSpace(TenLoai.Value))
            {
                ShowAlert("swal('Warning!','Chưa nhập đủ thông tin!','warning')");
            }
            else
            {
                if (DocumentManagement.Instance.reflectTypeFunc.ReflectType_Select_ReflectTypeName(this.TenLoai.Value) == null)
                {
                    ReflectType reflectType;
                    reflectType = new ReflectType
                    {
                        ReflectTypeID = int.Parse(IDLoaiPhanAnh.Value),
                        Name = TenLoai.Value,

                    };

                    DocumentManagement.Instance.reflectTypeFunc.ReflectType_InsertUpdate(reflectType);
                    LoadListBusTypePage(0);

                    ShowAlert("swal('Success!','Cập nhật loại phản ánh thành công!','success')");
                    ClearAll();

                    try
                    {
                        pivot = int.Parse(Request.QueryString["page"]);
                    }
                    catch
                    {
                        pivot = 0;
                    }

                    //Them do
                    PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                    isreadonly.SetValue(this.Request.QueryString, false, null);
                    Request.QueryString.Clear();
                }
                else
                {
                    ShowAlert("swal('Error!','Tên loại và hãng xe đã tồn tại!','error')");

                }

            }
            LoadListBusTypePage(pivot);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string selected = Request.Form["cbID"];
            if (selected != null && selected.Trim().Length > 0)
            {
                List<string> list = selected.Split(',').ToList();
                DocumentManagement.Instance.reflectTypeFunc.ReflectType_Delete_IDs(list);
                ShowAlert("swal('Success!','Xóa loại xe thành công!','success')");
            }
            LoadListBusTypePage(0);
            LoadPhanTrang();
        }

        private void ShowAlert(string note)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", note, true);
        }
        private void ClearAll()
        {
            IDLoaiPhanAnh.Value = "";
            TenLoai.Value = "";

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
            LoadListBusTypePage(PageIndex);
        }

        private void LoadListBusTypePage(int pIndex)
        {
            int TotalRows = 0;
            this.reflectTypes = DocumentManagement.Instance.reflectTypeFunc.ReflectType_Pagination(PageSize, pIndex, out TotalRows);
            this.hTotalRows.Value = TotalRows.ToString();
            if (reflectTypes == null || reflectTypes.Count == 0)
            {
                this.pnPhanTrang.Visible = false;
            }
            else
            {
                this.pnPhanTrang.Visible = true;
            }
        }
    }
}