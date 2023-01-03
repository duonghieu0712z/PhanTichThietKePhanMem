<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddData.aspx.cs" Inherits="Web.Pages.AddData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <asp:Button runat ="server" Text ="Thêm dữ liệu" ID="btn_add_data" OnClick ="btn_add_data_Click"/>
    <asp:Label runat="server"  ID ="test_file"/>
        </div>
    </form>
</body>
</html>
