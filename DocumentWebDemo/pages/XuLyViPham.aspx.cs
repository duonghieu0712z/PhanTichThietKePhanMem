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
    public partial class XuLyViPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridView();
            if (!IsPostBack)
            {

                LoadDropList();
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            HandlingViolation hv = new HandlingViolation();

            hv.Title = txtTitle.Text;
            hv.ResponsibleUnitID = int.Parse(txtIdDonvi.Text);
            hv.ProcessingTime = DateTime.Parse(txtDateSubmit.Text);
            hv.Content = txtContent.Text;
            DocumentManagement.Instance.handlingViolations.HandlingViolations_InsertUpdate(hv);
            LoadGridView();
            LoadDropList();
        }

        protected void BtnXoa_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(DroplistID.SelectedValue.ToString());
            DocumentManagement.Instance.handlingViolations.HandlingViotions_Delete(ID);
            LoadDropList();
            LoadText();
            LoadGridView();
        }

        protected void BtnCapNhat_Click(object sender, EventArgs e)
        {
            HandlingViolation info = new HandlingViolation();
            info.ID = int.Parse(DroplistID.SelectedValue.ToString());
            info.Title = txtTitle.Text;
            info.ResponsibleUnitID = int.Parse(txtIdDonvi.Text);
            info.ProcessingTime = DateTime.Parse(txtDateSubmit.Text);
            info.Content = txtContent.Text;
            DocumentManagement.Instance.handlingViolations.HandlingViolations_InsertUpdate(info);
            LoadGridView();
        }

        private void LoadGridView()
        {
            this.GridView1.DataSource = DocumentManagement.Instance.handlingViolations.HandlingViolation_Select_All();
            this.GridView1.DataBind();
        }
        private void LoadText()
        {
            this.txtContent.Text = "";
            this.txtIdDonvi.Text = "";
            this.txtDateSubmit.Text = "";
            this.txtTitle.Text = "";
        }
        private void LoadDropList()
        {
            DroplistID.DataSource = DocumentManagement.Instance.handlingViolations.HandlingViolation_Select_All();
            DroplistID.DataTextField = "ID";
            DroplistID.DataValueField = "ID";

            DroplistID.DataBind();
            DroplistID.Items.Insert(0, "-- Chọn ID --");
        }
        protected void DroplistID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(DroplistID.SelectedValue.ToString());
            HandlingViolation info = DocumentManagement.Instance.handlingViolations.HandlingViolation_Select_ID(ID);
            txtTitle.Text = info.Title;
            txtIdDonvi.Text = info.ResponsibleUnitID.ToString();
            txtDateSubmit.Text = info.ProcessingTime.ToString("yyyy-MM-dd");
            txtContent.Text = info.Content;

        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            string txt = txtFind.Text;
            this.GridView1.DataSource = DocumentManagement.Instance.handlingViolations.HandlingViolation_Select_By("Title",txt);
            this.GridView1.DataBind();
            if (txt == "")
            {
                LoadGridView();
            }
        }

        protected void txtFind_TextChanged(object sender, EventArgs e)
        {

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
                e.Row.Cells[0].Text = "ID";
                e.Row.Cells[1].Text = "Tiêu đề";
                e.Row.Cells[2].Text = "Id Đơn vi ";
                e.Row.Cells[3].Text = "Ngày đăng";
                e.Row.Cells[4].Text = "Nội dung";

                e.Row.Cells[0].Width = 50;
                e.Row.Cells[1].Width = 2000;
                e.Row.Cells[2].Width = 300;
                e.Row.Cells[3].Width = 200;
                e.Row.Cells[4].Width = 410;

            }
        }

    }

}