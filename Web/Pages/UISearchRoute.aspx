<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UISearchRoute.aspx.cs" Inherits="Web.Pages.UISearchRoute" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tìm kiếm Lộ trình</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous" />
</head>
<body>
    <form runat="server"  style="padding-left:52px; padding-right:52px">
        <div class="form-group">
        <div class="row">
            <div class="d-flex justify-content-center mt-4" style="width: 100%">
                <div class="col-sm-10">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="StartPositionName" placeholder="Nhập tên điểm bắt đầu" CssClass="form-control mb-1" 
                        AutoPostBack="true"
                        type="text"></asp:TextBox>
                    <asp:TextBox runat="server" ID="EndPosition" placeholder="Nhập tên điểm kết thúc" CssClass="form-control mb-1" 
                        AutoPostBack="true"
                        type="text"></asp:TextBox>
                </div>
                </div>
                <div class="col-sm-2 d-flex justify-content-center align-items-center">
                    <asp:Button style="height: 48px" Text="Tìm kiếm" runat="server" ID="btnSearch" CssClass="btn btn-primary" OnClick="btnSearch_Click"/>
                </div>
            </div>
        </div>

        <div class="row mt-4">
        <div class="col-sm-6 overflow-auto">
            <asp:Label id="lblRoute" Visible="false" runat="server"><h4>Danh sách Lộ trình</h4></asp:Label>
        <asp:GridView Visible="false" style="width:1200px" 
            OnRowDataBound="GridViewSearchRoute_RowDataBound" 
            ID="GridViewSearchRoute" 
            CssClass="table table-bordered table-striped" 
            runat="server" 
            AutoGenerateSelectButton="true"
            OnSelectedIndexChanged="GridViewSearchRoute_SelectedIndexChanged"
            SelectedRowStyle-BackColor="Gray"></asp:GridView>
        </div>
        <div class="col-sm-6 overflow-auto">
            <asp:Label id="lblBusStop" Visible="false" runat="server"><h4>Danh sách Điểm dừng</h4></asp:Label>
        <asp:GridView Visible="false" 
            ID="GridViewSearchBusStop" 
            OnRowDataBound="GridViewSearchBusStop_RowDataBound" 
            CssClass="table table-bordered table-striped" 
            runat="server" 
            ></asp:GridView>
        </div>
        </div>
            
        </div>
    </form>
        
</body>
</html>
