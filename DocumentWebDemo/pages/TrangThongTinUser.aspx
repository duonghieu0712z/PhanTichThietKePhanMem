<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="TrangThongTinUser.aspx.cs" Inherits="DocumentWebDemo.pages.TrangThongTinUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thông tin</title>

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<style>
    #header {
        display: flex;
        justify-content: space-between;
    }

    #search {
        display: flex;
        align-items: center;
        width: fit-content;
    }

    .body-content {
        margin: auto;
        background-color: white;
        max-width: 960px;
    }

    .infoLink {
        position: relative;
        display: flex;
        margin-bottom: 10px;
        box-shadow: 0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24);
        transition: all 0.3s cubic-bezier(.25,.8,.25,1);
        object-fit: cover;
        border-radius: 10px;
        overflow: hidden;
    }

    /*.infoLink:is(:hover) {
        box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22);
    }*/

    .infoLinkSpan {
        position: absolute;
        width: 100%;
        height: 100%;
        top: 0;
        left: 0;
        z-index: 1;
    }

    img, .img {
        object-fit: cover;
        width: 50px;
        height: 50px;
    }

    .infoTitle {
        font-size: 15px;
        font-weight: bold;
        min-width: 0;
    }

    .titleContainer {
        display: block;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
        max-width: 870px;
    }

    .infoTexts {
        display: flex;
        justify-content: space-between;
        flex-direction: column;
        padding: 0px 20px;
    }

    .time {
        font-size: 15px;
        padding-bottom: 5px;
        color: gray;
    }

    a {
        color: #34b67a;
    }

    a:is(:hover) {
        color: #34b67a;
    }
    
    p {
        min-width: 0;
        min-height: 0;
    }
</style>
<body class="body-content">
    <form id="form1" runat="server">
        <br />
        <div id="header">
            <h1>Thông tin</h1>
            <div id="search">
                <asp:TextBox ID="txtFind" class="form-control" runat="server" Width="222px"></asp:TextBox>
                <asp:Button ID="btnFind" class="btn btn-primary" runat="server" Height="35px" Text="Tìm" OnClick="btnFind_Click" />
            </div>
        </div>
        <hr />

        <%
            foreach (var info in informations)
            {
        %>
        <div class="infoLink">
            <div class="img"><%= info.Image%></div>
            <div class="infoTexts">
                <div class="titleContainer">
                    <a href="NoiDung.aspx?id=<%=info.ID%>" class="infoTitle"><%= info.Title%><span class="infoLinkSpan"></span></a>
                </div>
                <span class="time">Ngày đăng: <%= info.DateSubmitted %></span>
            </div>
        </div>
        <%
            }
        %>
    </form>
</body>
</html>
