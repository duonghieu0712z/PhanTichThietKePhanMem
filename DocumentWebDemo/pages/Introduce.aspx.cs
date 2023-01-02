using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.IO;
using DocumentLayer;
using DocumentLayer.MasterSystem;

namespace DocumentWebDemo.pages
{

    public partial class Introduce : System.Web.UI.Page
    {
        public bool HasFile { get; }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }




        protected void btnUpload_Click(object sender, EventArgs e)
        {
            

            

            if (this.FileUpload1.FileName != "")
            {
                Introduction obj = this.GetValue();

                this.FileUpload1.PostedFile.SaveAs(Server.MapPath(@"ImgPath\") + obj.Picture);

                DocumentManagement.Instance.introduce.InsertUpdate(obj);

                Label1.Text = "thêm thành công!";
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Bạn chưa chọn file!");
            }
            
            //try
            //{
            //    using (SqlConnection sqlCon = new SqlConnection(connectionString))
            //    {
            //        if (FileUpload1.HasFile)
            //        {
            //            sqlCon.Open();
            //            string query = "insert into Introduction(IntroductionID, Title, Content, Picture) values (@IntroductionID,@Title,@Content,@Picture)";
            //            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            //            FileUpload1.SaveAs(Server.MapPath("~/ImgPath/") + System.IO.Path.GetFileName(FileUpload1.FileName));
            //            string linkPath = "ImgPath/" + System.IO.Path.GetFileName(FileUpload1.FileName);

            //            sqlCommand.Parameters.AddWithValue("@IntroductionID", txtID.Text);
            //            sqlCommand.Parameters.AddWithValue("@Title", txtTitle.Text);
            //            sqlCommand.Parameters.AddWithValue("@Content", txtContent.Text);
            //            sqlCommand.Parameters.AddWithValue("@Picture", linkPath);

            //            sqlCommand.ExecuteNonQuery();
            //            sqlCon.Close();
            //        }
            //    }
            //    System.Windows.Forms.MessageBox.Show("Thêm thành công");
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show("Có lỗi xảy ra!!!");
            //}
        }

        private Introduction GetValue()
        {
            Introduction gt = new Introduction();
            
                gt.IntroductionID = int.Parse(txtID.Text);
                gt.Title = this.txtTitle.Text;
                gt.Content = this.txtContent.Text;
                gt.Picture = this.FileUpload1.FileName; 

            return gt;
        }
    }
}