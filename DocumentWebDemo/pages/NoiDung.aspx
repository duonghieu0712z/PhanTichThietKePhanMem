<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="NoiDung.aspx.cs" Inherits="DocumentWebDemo.pages.NoiDung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= information.Title %></title>
</head>
<style>
    .body-content {
        margin: auto;
        background-color: white;
        max-width: 960px;
    }

    /*#coverImage img{
        object-fit: contain;
        max-width: 100%
    }*/
</style>
<body class="body-content">
    <form id="form1" runat="server">
        <br />
        <div id="header">
            <h1><%= information.Title %></h1>
        </div>
        <hr />

        <div>
            <%--<div id="coverImage"><%= information.Image %></div>--%>
            <p><%= information.Content %></p>
        </div>
    </form>
</body>
</html>