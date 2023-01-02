<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Introduce.aspx.cs" Inherits="DocumentWebDemo.pages.Introduce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/webmainCss.css" rel="stylesheet" />
    <div class="img-frame" runat="server">
        <div class="row1" runat="server" style="height:500px; width:1000px; margin-top:100px; margin-left:400px ; font-family:'Times New Roman', Times, serif; font-style:normal; font-size:medium;font-weight:bold">
            <asp:Label runat="server" Text="ID" Width="80px"></asp:Label>
            <asp:TextBox ID="txtID" runat="server" BorderStyle="Double"></asp:TextBox><br />
            <asp:Label runat="server" Text="Tiêu đề" Width="80px"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" BorderStyle="Double"></asp:TextBox><br />
            <asp:Label runat="server" Text="Nội dung" Width="80px"></asp:Label>
            <asp:TextBox ID="txtContent" runat="server" BorderStyle="Double"></asp:TextBox><br />
            <asp:Label runat="server" Text="Đường dẫn" Width="80px"></asp:Label>
            <asp:FileUpload runat="server" ID="FileUpload1" ></asp:FileUpload>
            <asp:Button ID="btnUpload" runat="server" Text="Tải lên" Font-Bold="true" BorderStyle="Double" BorderColor="DarkGreen" BackColor="ForestGreen" ForeColor="White" OnClick="btnUpload_Click"></asp:Button>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Content>
