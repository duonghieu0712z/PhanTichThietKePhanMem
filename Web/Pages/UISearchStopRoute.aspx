<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UISearchStopRoute.aspx.cs" Inherits="Web.Pages.UISearchStopRoute" %>
<asp:Content ID="UISearchStopRoute" ContentPlaceHolderID="Head" runat="server">
     <asp:TextBox runat="server" ID="UISearchStopRouteRouteName" TextMode="SingleLine" Text="Nhập tên lộ trình..." Columns="40"></asp:TextBox>
        <asp:Button runat="server" ID="ButtonSearchStopRouteByRouteName" Text="Tìm kiếm điểm dừng"/>
        <div runat="server">
            <h2>Danh sách kết quả điểm dừng thuộc lộ trình: </h2>
            <asp:GridView ID="GridViewUISearchStopRouteListStopRoute" runat="server"></asp:GridView>
            <h2>Thông tin điểm dừng: </h2>
            <asp:GridView ID="GridViewUISearchStopRouteStopRouteInfomation" runat="server"></asp:GridView>
        </div>
</asp:Content>

