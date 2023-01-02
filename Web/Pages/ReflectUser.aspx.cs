using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.Functions;


namespace Web.Pages
{
    public partial class ReflectUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadReflectType();
            }
        }
        private void LoadReflectType()
        {
            this.drlType.Items.Clear();
            this.drlType.DataSource = HRFunctions.Instance.SelectAllReflectType();
            this.drlType.DataTextField = "Name";
            this.drlType.DataValueField = "ReflectTypeID";
            this.DataBind();
            this.drlType.Items.Insert(0, "Tất cả");
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!CheckNull())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Không được để trống thông tin')", true);
            }
            else if (HRFunctions.Instance.FindBusByTitle(this.txtTitle.Value) == null)
            {
                BusinessLayer.DBAccess.Reflect obj = new BusinessLayer.DBAccess.Reflect();
                {
                    obj.ReflectTypeID = int.Parse(this.drlType.SelectedValue);
                    obj.Title = this.txtTitle.Value;
                    obj.Email = this.txtEmail.Value;
                    obj.FullName = this.txtName.Value;
                    obj.PhoneNumber = this.txtPhoneNumber.Value;
                    obj.Content = this.txtContent.Value;
                    obj.VideoOrPicture = "../images/" + System.IO.Path.GetFileName(txtFile.FileName);
                    obj.Status = "Chưa xử lý";



                };
                txtFile.SaveAs(Server.MapPath("~/images/") + System.IO.Path.GetFileName(txtFile.FileName));
                HRFunctions.Instance.AddReflect(obj);
                Clear();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Gửi phản ánh thành công')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Kiểm tra lại thông tin')", true);
            }

        }
        private void ShowAlert(string note)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", note, true);
        }
        protected void Clear()
        {
            this.drlType.SelectedIndex = 0;
            this.txtTitle.Value = "";
            this.txtEmail.Value = "";
            this.txtName.Value = "";
            this.txtPhoneNumber.Value = "";
            this.txtContent.Value = "";

        }
        protected bool CheckNull()
        {
            if (string.IsNullOrWhiteSpace(this.txtTitle.Value) || string.IsNullOrWhiteSpace(this.txtPhoneNumber.Value) ||
                string.IsNullOrWhiteSpace(this.txtEmail.Value) || string.IsNullOrWhiteSpace(this.txtName.Value) ||
                this.drlType.Text == "Tất cả" || string.IsNullOrWhiteSpace(this.txtContent.Value) ||
                string.IsNullOrWhiteSpace(this.txtFile.UniqueID))
            {
                return false;
            }
            return true;
        }
    }
}