<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UISearchStopRoute.aspx.cs" Inherits="Web.Pages.UISearchStopRoute" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tra cứu thông tin điểm dừng thuộc lộ trình</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox runat="server" ID="UISearchStopRouteRouteName" TextMode="SingleLine" PlaceHolder="Nhập tên lộ trình..." Columns="40"></asp:TextBox>
        <asp:Button runat="server" ID="ButtonSearchStopRouteByRouteName" Text="Tìm kiếm điểm dừng"/>
        <div runat="server">
            <h2>Danh sách kết quả điểm dừng thuộc lộ trình: </h2>
            <asp:GridView ID="GridViewUISearchStopRouteListStopRoute" runat="server"></asp:GridView>
            <h2>Thông tin điểm dừng: </h2>
            <asp:GridView ID="GridViewUISearchStopRouteStopRouteInfomation" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
