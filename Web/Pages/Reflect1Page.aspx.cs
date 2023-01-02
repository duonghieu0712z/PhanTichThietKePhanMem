using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.DBAccess;
using Microsoft.Ajax.Utilities;
using BusinessLayer.Functions;
using System.Net.Mail;
using System.Reflection;

namespace Web.Pages
{
    public partial class Reflect1Page : System.Web.UI.Page
    {

        List<int> list = new List<int> { 1, 2, 3, 4, 5 };
        int PageSize = 5;
        public int pivot = 0;
        //int PageSize = 2;

        public List<BusinessLayer.DBAccess.Reflect> listPhanAnh;
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bạn không được để trống')", true);
            }
            else if (HRFunctions.Instance.FindBusByTitle(this.tieude.Value) == null)
            {
                BusinessLayer.DBAccess.Reflect reflect = new BusinessLayer.DBAccess.Reflect
                {
                    Title = this.tieude.Value,
                    PhoneNumber = this.sdt.Value,
                    Email = this.gmail.Value,
                    FullName = this.hoten.Value,
                    Content = this.noidung.Value,
                    ReflectTypeID = int.Parse(this.phananhlist.Text),
                    VideoOrPicture = this.linkvideo.Value,
                    Status = this.trangthai.Value


                };
                HRFunctions.Instance.AddReflect(reflect);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thêm phản ánh thành công')", true);
                ClearInput();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Tiêu đề đã tồn tại')", true);
            }
            LoadListBusPage(0, false);
            LoadDropDownList();
        }


        protected bool CheckNull()
        {
            if (string.IsNullOrWhiteSpace(this.tieude.Value) || string.IsNullOrWhiteSpace(this.sdt.Value) ||
                string.IsNullOrWhiteSpace(this.gmail.Value) || string.IsNullOrWhiteSpace(this.hoten.Value) ||
                this.phananhlist.Text == "Tất cả" || string.IsNullOrWhiteSpace(this.noidung.Value) ||
                string.IsNullOrWhiteSpace(this.linkvideo.Value) || string.IsNullOrWhiteSpace(this.trangthai.Value))
            {
                return false;
            }
            return true;
        }

        protected void ClearInput()
        {
            this.ReflectID.Value = "";
            this.tieude.Value = "";
            this.sdt.Value = "";
            this.gmail.Value = "";
            this.hoten.Value = "";
            this.noidung.Value = "";
            this.linkvideo.Value = "";
            this.trangthai.Value = "";
            this.txtKeyword.Value = "";
            this.phananhlist.SelectedIndex = 0;
        }


        private void LoadEditButton()
        {
            try
            {

                int idEdit = int.Parse(Request.QueryString["idedit"]);
                BusinessLayer.DBAccess.Reflect reflect = HRFunctions.Instance.FindReflectByID(idEdit);
                if (reflect != null)
                {
                    this.ReflectID.Value = reflect.ID.ToString();
                    this.tieude.Value = reflect.Title;
                    this.sdt.Value = reflect.PhoneNumber;
                    this.gmail.Value = reflect.Email.ToString();
                    this.hoten.Value = reflect.FullName;
                    this.noidung.Value = reflect.Content;
                    this.linkvideo.Value = reflect.VideoOrPicture;
                    this.trangthai.Value = "Đã xử lý";


                    ReflectType reflectType = HRFunctions.Instance.FindReflectTypeByID(reflect.ReflectTypeID);

                    this.phananhlist.SelectedValue = phananhlist.ToString();
                    pivot = int.Parse(Request.QueryString["page"]);
                    //LoadListBusPage(0);
                    LoadListBusPage(pivot, false);

                }
            }
            catch { }
        }

        protected void UpdateBusButton_Click(object sender, EventArgs e)
        {
            if (!CheckNull())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bạn không được để trống')", true);
            }
            else if (HRFunctions.Instance.FindBusByTitle(this.tieude.Value) == null ||
                HRFunctions.Instance.FindReflectByID(int.Parse(this.ReflectID.Value)).Title == this.tieude.Value
                )
            {
                if (string.IsNullOrWhiteSpace(this.ReflectID.Value))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Chưa chọn phản ánh cập nhật')", true);
                }
                else
                {
                    BusinessLayer.DBAccess.Reflect reflect = HRFunctions.Instance.FindReflectByID(int.Parse(this.ReflectID.Value));

                    reflect.ReflectTypeID = int.Parse(this.phananhlist.Text);
                    reflect.Title = this.tieude.Value;
                    reflect.PhoneNumber = this.sdt.Value;
                    reflect.Email = this.gmail.Value;
                    reflect.FullName = this.hoten.Value;
                    reflect.Content = this.noidung.Value;
                    reflect.VideoOrPicture = this.linkvideo.Value;
                    reflect.Status = "Đã Xử Lý";


                    HRFunctions.Instance.AddReflect(reflect);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Phản Hồi phản ánh thành công')", true);

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
                    ClearInput();
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Tiêu đề phản ánh đã tồn tại')", true);
                this.tieude.Value = "";

            }

            LoadListBusPage(pivot, false);
        }

        private void ShowAlert(string note)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", note, true);
        }

        protected void LoadDropDownList()
        {
            this.phananhlist.DataSource = HRFunctions.Instance.SelectAllReflectType();
            this.phananhlist.DataTextField = "Name";
            this.phananhlist.DataValueField = "ReflectTypeID";
            this.phananhlist.DataBind();
            this.phananhlist.Items.Insert(0, "Tất cả");
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

        private void LoadListBusPage(int pIndex, bool isSearch = true)
        {
            string query = "";
            if (isSearch == true)
            {
                query = SearchReflectByCriteria();
            }
            int TotalRows = 0;

            this.listPhanAnh = HRFunctions.Instance.SearchReflectCriteria(query, PageSize, pIndex, out TotalRows);

            this.hTotalRows.Value = TotalRows.ToString();
            if (listPhanAnh == null || listPhanAnh.Count == 0)
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
                HRFunctions.Instance.DeleteReflectByIDs(list);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Xóa phản ánh thành công')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Gửi phản ánh thành công')", true);
            }
            LoadListBusPage(0);
            LoadPhanTrang();
        }

        protected string SearchReflectByCriteria()
        {
            string reflectType = phananhlist.Text != "Tất cả" ? $"ReflectTypeID={int.Parse(this.phananhlist.Text)} and " : "";
            string td = !tieude.Value.IsNullOrWhiteSpace() ? $"TitLe='{tieude.Value}' and " : "";
            string st = !sdt.Value.IsNullOrWhiteSpace() ? $"PhoneNumber='{sdt.Value}' and " : "";
            string gm = !gmail.Value.IsNullOrWhiteSpace() ? $"Email='{gmail.Value}' and " : "";
            string ht = !hoten.Value.IsNullOrWhiteSpace() ? $"FullName=N'{hoten.Value}' and " : "";
            string nd = !noidung.Value.IsNullOrWhiteSpace() ? $"Content=N'{noidung.Value}' and " : "";
            string vd = !linkvideo.Value.IsNullOrWhiteSpace() ? $"VideoOrPicture=N'{linkvideo.Value}' and " : "";
            string tt = !trangthai.Value.IsNullOrWhiteSpace() ? $"Status=N'{trangthai.Value}' and " : "";



            string multiQuery = $"{td + st + gm + ht + nd + vd + reflectType + tt}";
            if (multiQuery != "")
            {
                int lastPs = multiQuery.LastIndexOf("and");
                multiQuery = multiQuery.Substring(0, lastPs);
                multiQuery = "where " + multiQuery;
            }
            return multiQuery;
        }
        protected void LoadTimKiem(int pIndex)
        {
            int Pagesize = int.Parse(this.dlPageNumber.SelectedValue);
            int TotalRows = 0;
            this.listPhanAnh = HRFunctions.Instance.Reflect_Find_KeyWord(Pagesize, pIndex, out TotalRows);
            this.hTotalRows.Value = TotalRows.ToString();
            if (listPhanAnh == null || listPhanAnh.Count == 0)
            {
                this.pnPhanTrang.Visible = false;
                this.pnTable.Visible = false;
                this.tieude.Value = "không tìm thấy dữ liệu";
                this.hoten.Value = "Không tìm thấy dữ liệu";
                this.Label1.Text = "Không tìm thấy dữ liệu";
            }
        }

        protected void dlPageNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PageIndex = int.Parse(this.hPageIndex.Value);
            this.LoadTimKiem(PageIndex);
            Global.g_PageSize = this.dlPageNumber.SelectedValue;

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
            return HRFunctions.Instance.GetReflectTypeByID(id).Name;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(gmail.Value.ToString().Trim());
            mail.From = new MailAddress("phanquochuy2001na@gmail.com");
            mail.Subject = "Phản hồi phản ánh";
            mail.Body = txtContent.Value.ToString();
            /*"<p>Xin chào bạn<br/> Chúng tôi đã nhận được phản ánh từ bạn và chúng tôi rất cảm ơn những đóng góp quả bạn để giúp cho công ty phát triển thêm chúng tôi sẽ cố gắng xử lý một cách nhanh chóng và triệt để những đóng góp của bạn </p>";*/
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587; // 25 465
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("phanquochuy2001na@gmail.com", "gzaswfkwvkybznig");
            smtp.Send(mail);
        }


    }

}
