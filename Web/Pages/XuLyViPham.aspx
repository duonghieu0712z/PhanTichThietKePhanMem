<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="XuLyViPham.aspx.cs" Inherits="Web.Pages.XuLyViPham" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

</head>
<style>
    .paging {
        display: flex;
        justify-content: flex-end;
    }

    .body-content {
        max-width: 960px;
        margin: auto;
        background-color: white;
    }

    .search {
        display: flex;
        align-items: center;
        width: fit-content;
    }

    

    #functions {
        background-color: #f1f1f1;
        padding: 20px;
        margin: 20px 0px 20px 0px;
        border-radius: 10px;
     

    }
    h1, #txtFind {
        display: inline;
    }
    #txtFind {
        margin: 0px 5px;
    }

    #header {
        display: flex;
        justify-content: space-between;
    }

    .button-functions {
        margin-top: 30px;
        display: flex;
        justify-content: flex-end;
        gap: 5px;
        
    }

    .rows, .header {
        border: none 0px transparent;
    }

    .pager {
        border: none;
    }

    #fields-container {
        display: flex;
        justify-content: space-evenly;
    }

    #table {
        font-size: 12px;
    }
</style>
<body class="body-content">
    <form id="form1" runat="server">
        <br />
        <div id="header">
            
            <h1>XỬ LÝ VI PHẠM</h1>
            <div class="search">
                <asp:TextBox ID="txtFind" class="form-control" runat="server" Width="422px" OnTextChanged="txtFind_TextChanged"></asp:TextBox>
                <asp:Button ID="btnFind" class="btn btn-primary" runat="server" Height="35px" Width="80px" Text="Tìm" OnClick="btnFind_Click" />
            </div>
        </div>
        <hr />
        <div id="table">
            <asp:GridView ID="GridView1" class="table table-striped table-hover table-bordered" runat="server" Font-Bold="False"
                HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging" HorizontalAlign="Center" OnRowDataBound="GridView1_RowDataBound">
                <FooterStyle BorderStyle="None" />
     
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderStyle="None" />
                <PagerStyle BorderStyle="None" BorderWidth="0px" />

                <RowStyle CssClass="rows"></RowStyle>
               
               
               
               
            </asp:GridView>
        </div>
        <div id="functions">
            <div id="fields-container">
                <div id="fields1">
                    <label for="DroplistID">ID</label>
                    <asp:DropDownList ID="DroplistID" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DroplistID_SelectedIndexChanged" Width="230px">
                    </asp:DropDownList>

                    <label for="txtTitle">Tiêu đề</label>
                    <asp:TextBox ID="txtTitle" class="form-control" runat="server" Width="230px"></asp:TextBox>

                    <label for="txtIdDonvi">id Đơn vị đảm nhận </label>
                    <asp:TextBox ID="txtIdDonvi" class="form-control" runat="server" Width="230px" ></asp:TextBox>

                    <label for="txtDateSubmit">Ngày giờ</label>
                    <asp:TextBox ID="txtDateSubmit" class="form-control" runat="server" Width="230px" TextMode="Date"></asp:TextBox>
                </div>

                <div id="fields2">
                     
                    <label for="txtContent">Nội dung</label>
                    <asp:TextBox ID="txtContent" class="form-control" runat="server" Width="650px" Height="185px" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>

            <div class="button-functions">
                <asp:Button ID="BtnThem" class="btn btn-primary" runat="server"  Height="35px" Width="80px" OnClick="Button2_Click" Text="Thêm" />
               
                <asp:Button ID="BtnCapNhat" class="btn btn-primary" runat="server"  Height="35px" Width="80px" OnClick="BtnCapNhat_Click" Text="Cập nhật" />

                 <asp:Button ID="BtnXoa" class="btn btn-danger" runat="server"  Height="35px" Width="80px" OnClick="BtnXoa_Click" Text="Xoá" />
            </div>
        </div>
    </form>
</body>
</html>
