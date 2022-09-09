<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StopRoutePage.aspx.cs" Inherits="Web.Pages.StopRoutePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý lộ trình - điểm dừng</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <div runat="server">
            <h2>Danh sách lộ trình - điểm dừng: </h2><br />
            <asp:GridView ID="GridViewStopRoute" runat="server"></asp:GridView>
        </div>
        <asp:Label runat="server">ID Lộ trình - điểm dừng (sửa, xóa):</asp:Label><br />
        <asp:TextBox runat="server" ID="StopRouteIDStopRoute" TextMode="SingleLine"></asp:TextBox>
        <asp:Button runat="server" ID="ButtonDeleteStopRoute" Text="Xóa lộ trình - điểm dừng"/>
        <br />
        <asp:Label runat="server">ID Lộ trình:</asp:Label><br />
        <asp:TextBox runat="server" ID="StopRouteIDRoute" TextMode="SingleLine"></asp:TextBox>
        <br />
        <asp:Label runat="server">ID Điểm dừng:</asp:Label><br />
        <asp:TextBox runat="server" ID="StopRouteIDStoping" TextMode="SingleLine"></asp:TextBox>
        <br />
        <asp:Label runat="server">Số thứ tự:</asp:Label><br />
        <asp:TextBox runat="server" ID="StopRouteOrder" TextMode="SingleLine"></asp:TextBox>
        <br /><br />
            <asp:Button runat="server" ID="ButtonAddStopRoute" Text="Thêm lộ trình - điểm dừng" OnClick="ButtonAddStopRoute_Click"/>
            <asp:Button runat="server" ID="ButtonUpdateStopRoute" Text="Sửa lộ trình - điểm dừng"/>
        <br /><br />
        <asp:TextBox runat="server" TextMode="MultiLine" ID="TestPlace" Columns="40" Rows="20"></asp:TextBox>
    </form>
    <div class="container">
  <div class="row">
    <div class="col-sm">
      One of three columns
    </div>
    <div class="col-sm">
      One of three columns
    </div>
    <div class="col-sm">
      One of three columns
    </div>
  </div>
</div>
</body>
</html>


