using BusinessLayer;
using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading.Tasks;
using BusinessLayer.Functions;

namespace QuanlyThongtin.Pages
{
    public partial class TrangThongtin : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;initial catalog=ROUTE_MANAGEMENT;integrated security=True;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridView();
                LoadDropList();
                LoadText();
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTitle.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tiêu đề không được để trống!')", true);
            }
            else if (String.IsNullOrEmpty(txtDateSubmit.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ngày giờ không được để trống!')", true);
            }
            if (String.IsNullOrEmpty(editor.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Nội dung không được để trống!')", true);
            }
            if (String.IsNullOrEmpty(editor2.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Hình không được để trống!')", true);
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Information(Image,Title,DateSubmitted,Content) values (@Image,@Title,@DateSubmitted,@Content)", conn);
                cmd.Parameters.AddWithValue("@Image", HttpUtility.HtmlDecode(editor2.Text));
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@DateSubmitted", DateTime.Parse(txtDateSubmit.Text));
                cmd.Parameters.AddWithValue("@Content", HttpUtility.HtmlDecode(editor.Text));
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadGridView();
                LoadDropList();

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Thêm thành công.')", true);
            }
        }

        protected void BtnXoa_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(DroplistID.SelectedValue.ToString());
            HRFunctions.Instance.DeleteInfo(ID);
            LoadDropList();
            LoadText();
            LoadGridView();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Xoá thành công.')", true);
        }

        protected void BtnCapNhat_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            info.ID = int.Parse(DroplistID.SelectedValue.ToString());
            info.Title = txtTitle.Text;
            info.Image = editor2.Text;
            info.DateSubmitted = DateTime.Parse(txtDateSubmit.Text);
            info.Content = editor.Text;
            HRFunctions.Instance.InsertUpdateInfo(info);
            LoadGridView();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cập nhật thành công.')", true);
        }

        private void LoadGridView()
        {
            //this.GridView1.DataSource = HRFunctions.Instance.SelectAll();
            //this.GridView1.DataBind();
            conn.Open();
            string searchData = txtFind.Text.Trim();
            string query = "Select ID,Title,Image,DateSubmitted,Content from Information ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            conn.Close();
            //if (txtFind.Text == "")
            //{
            //    LoadGridView();
            //    LoadDropList();
            //}
        }
        private void LoadText()
        {
            this.editor.Text = "";
            this.editor2.Text = "";
            this.txtDateSubmit.Text = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
            this.txtTitle.Text = "";
        }
        private void LoadDropList()
        {
            DroplistID.DataSource = HRFunctions.Instance.SelectAll();
            DroplistID.DataTextField = "ID";
            DroplistID.DataValueField = "ID";

            DroplistID.DataBind();
            DroplistID.Items.Insert(0, "-- Chọn Thông tin --");
        }
        protected void DroplistID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(DroplistID.SelectedValue,out int test))
            {
                int ID = int.Parse(DroplistID.SelectedValue.ToString());
                Information info = HRFunctions.Instance.GetInfo_FromID(ID);
                txtTitle.Text = info.Title;
                txtDateSubmit.Text = info.DateSubmitted.ToString("yyyy-MM-ddThh:mm");
                editor.Text = info.Content;
                editor2.Text = info.Image;
                BtnThem.Visible = false;
                BtnCapNhat.Visible = true;
            }
            else
            {
                LoadText();
                BtnThem.Visible = true;
                BtnCapNhat.Visible = false;
            }
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            conn.Open();
            string searchData = txtFind.Text.Trim();
            string query = "Select ID,Title,Image,DateSubmitted,Content from Information ";
            query += "where ID like '%" + searchData + "%'";
            query += "or Image like N'%" + searchData + "%'";
            query += "or Title like N'%" + searchData + "%'";
            query += "or DateSubmitted like '%" + searchData + "%'";
            query += "or Content like N'%" + searchData + "%'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            conn.Close();
            if (txtFind.Text == "")
            {
                LoadGridView();
                LoadDropList();
            }
        }

        protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadGridView();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        { 
            
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "ID";
                e.Row.Cells[2].Text = "Tiêu đề";
                e.Row.Cells[3].Text = "Hình ảnh";
                e.Row.Cells[4].Text = "Ngày đăng";
                e.Row.Cells[5].Text = "Nội dung";
            }
        }

        protected void btnXoaTatCa_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from Information ", conn);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Xoá thành công')", true);
            conn.Close();
            LoadGridView();
            LoadDropList();
            
        }

        protected void DeleteSelected_Click(object sender, EventArgs e)
        {
            int ID = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chkSelect = (CheckBox)GridView1.Rows[i].FindControl("ChkSelect");
                if (chkSelect.Checked==true)
                {
                    ID = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"Delete from Information where ID = {ID}", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(),"alert","alert('Xoa thanh cong')",true);
            LoadGridView();
            LoadDropList();
        }
    }
}