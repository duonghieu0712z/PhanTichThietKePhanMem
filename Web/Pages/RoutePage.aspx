<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoutePage.aspx.cs" Inherits="Web.Pages.RoutePage" %>

<asp:Content ID="route" ContentPlaceHolderID="MainContent" runat="server">
 
      <div runat="server">
            <h2>Danh sách lộ trình: </h2><br />
<asp:GridView ID="GridViewRoute" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridViewRoute_SelectedIndexChanged"></asp:GridView>
        </div>
        <div runat="server" id="RouteContentForm">
            <asp:Label runat="server">ID Lộ trình (sửa, xóa):</asp:Label><br />
            <asp:TextBox runat="server" ID="RouteIDRoute" TextMode="SingleLine" ReadOnly="true"></asp:TextBox>
            <asp:Button runat="server" ID="ButtonDeleteRoute" Text="Xóa lộ trình" OnClick="ButtonDeleteRoute_Click" />
            <br />
            <asp:Label runat="server">ID Tuyến:</asp:Label><br />
            <asp:TextBox runat="server" ID="RouteIDBusRoute" TextMode="SingleLine"></asp:TextBox>
            <br />
            <asp:Label runat="server">ID Điểm bắt đầu:</asp:Label><br />
            <asp:TextBox runat="server" ID="RouteIDStartPoint" TextMode="SingleLine"></asp:TextBox>
            <br />
            <asp:Label runat="server">ID Điểm kết thúc:</asp:Label><br />
            <asp:TextBox runat="server" ID="RouteIDEndPoint" TextMode="SingleLine"></asp:TextBox>
            <br />
            <asp:Label runat="server">Tên lộ trình:</asp:Label><br />
            <asp:TextBox runat="server" ID="RouteRouteName" TextMode="SingleLine"></asp:TextBox>
            <br />
            <asp:Label runat="server">Số chuyến:</asp:Label><br />
            <asp:TextBox runat="server" ID="RoutesNumber" TextMode="SingleLine"></asp:TextBox>
            <br />
            <asp:Label runat="server">Thời gian chuyến (trung chuyển - phút):</asp:Label>
            <br />
            <asp:TextBox runat="server" ID="RoutesTime" TextMode="SingleLine"></asp:TextBox>
            <br />
            <asp:Label runat="server">Thời gian bắt đầu hoạt động:</asp:Label><br />
            <asp:TextBox runat="server" ID="RouteStartActiveTime" TextMode="Time" />
            <br />
            <asp:Label runat="server">Thời gian kết thúc hoạt động:</asp:Label><br />
            <asp:TextBox runat="server" ID="RouteFinishActiveTime" TextMode="Time"></asp:TextBox>
            <br />
            <asp:Label runat="server">Ngày áp dụng:</asp:Label><br />
            <asp:TextBox runat="server" ID="RouteApplicable" TextMode="Date"></asp:TextBox>
            <br />
            <asp:Label runat="server">Ngày hoạt động:</asp:Label><br />
            <asp:TextBox runat="server" ID="RouteOperation" TextMode="SingleLine"></asp:TextBox>
            <br />
            <br />
            <asp:Button runat="server" ID="ButtonAddRoute" Text="Thêm lộ trình" OnClick="ButtonAddRoute_Click" />
            <asp:Button runat="server" ID="ButtonUpdateRoute" Text="Sửa lộ trình" OnClick="ButtonUpdateRoute_Click" />
            <br />
            <br />
            <asp:TextBox runat="server" ID="TestPlace" TextMode="MultiLine" Rows="20" Columns="40"></asp:TextBox>
        </div>

</asp:Content>


      

