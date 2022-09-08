<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StopRoutePage.aspx.cs" Inherits="Web.Pages.StopRoutePage" %>

<asp:Content ID="StopRoute" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server">
            <h2>Danh sách lộ trình - điểm dừng: </h2><br />
            <asp:GridView ID="GridViewStopRoute" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridViewStopRoute_SelectedIndexChanged"></asp:GridView>
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
</asp:Content>
