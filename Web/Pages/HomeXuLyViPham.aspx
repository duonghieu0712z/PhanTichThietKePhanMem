<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="HomeXuLyViPham.aspx.cs" Inherits="Web.Pages.HomeXuLyViPham" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>



    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <style>
        .paging {
            display: flex;
            justify-content: flex-end;
        }

        .body-content {
            max-width: 960px;
            margin: auto;
            background-color: white;
        }

        #table {
            font-size: 12px;
        }
    </style>
</head>
<body class="body-content">
    <form id="form1" runat="server">
        <br />
        <div id="header">

            <h1>XỬ LÝ VI PHẠM</h1>

        </div>
        <hr />
        <div id="table">
            <table class="table table-bordered bg-light">
                <thead class="table-secondary">
                    <tr class="text-center text-nowrap">
                        <th>Tiêu đề</th>
                        <th>Thời gian xử lý</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (var item in ls)
                        { %>
                    <tr class="item" style="display: none">
                        <td><%=item.Title %></td>
                        <td><%=item.ProcessingTime.ToString("dd/MM/yyyy") %></td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
            <button class="rmoreBtn">Xem thêm</button>
        </div>
    </form>
    <script>
        $(".item").slice(0, 15).show();

        $(".rmoreBtn").on("click", () => {
            event.preventDefault();
            $(".item:hidden").slice(0, 5).show();
            if ($(".item:hidden").length == 0) {
                $(".rmoreBtn").fadeOut();
            }
        })
    </script>
</body>
</html>

