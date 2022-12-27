<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="BusManagement.Pages.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <label for="exampleFormControlInput1" class="form-label">Email address</label>
        <input type="email" class="form-control" id="exampleFormControlInput1" placeholder="name@example.com" />
        <table class="table table-primary caption-top table-striped table-hover table-bordered">
            <caption class="text-center">DANH SÁCH CÁC LOẠI XE</caption>
            <thead>
                <tr>
                    <th class="text-center" scope="col">ID</th>
                    <th class="text-center" scope="col">Tên Loại</th>
                    <th class="text-center" scope="col">Hãng Xe</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var busType in BustypeList)
                    { %>
                <tr>
                    <th class="text-center" scope="row"><%= busType.BusTypeID %></th>
                    <td><%= busType.Name %></td>
                    <td><%= busType.CarMaker %></td>
                </tr>
                <% } %>
            </tbody>
        </table>        
    </form>
</body>
</html>
