<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="XuLyViPhamHome.aspx.cs" Inherits="Web.Pages.XuLyViPhamHome" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
      
    <style type="text/css">
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

    
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
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
 </asp:Content>

