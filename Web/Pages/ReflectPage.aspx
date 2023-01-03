<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReflectPage.aspx.cs" Inherits="Web.Pages.ReflectPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../CSS/test.css" rel="stylesheet" type="text/css" />
    <div class="detail">
    <h1 class="mt-3" style="text-align: center; color: #008000; font-weight: bold;">Quản lý phản ánh</h1>
    <div class="container my-3 py-3">
        <div class="row mb-3">
            <label for="IDLoaiXe" class="form-label col-2">ID</label>
            <input style="background: #f1f1f1;" id="IDLoaiPhanAnh" type="text" readonly class="form-control col" placeholder="ID Loại Phản Ánh" runat="server">
        </div>
        <div class="row mb-3">
            <label for="TenLoai" class="form-label col-2">Tên loại</label>
            <input id="TenLoai" type="text" class="form-control col" placeholder="Nhập vào tên loại xe" runat="server">
        </div>

        <div class="d-flex justify-content-end">
            <asp:Button ID="AddBusButton" OnClick="Insert_Click" runat="server" Text="Thêm Mới" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary" />
            <asp:Button ID="UpdateBusButton" href="?page=<%=this.pivot%>" OnClick="Update_Click" runat="server" Text="Cập Nhật" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary ml-2" />
            <asp:Button ID="DeleteBusButton" OnClientClick="return confirm('Bạn có muốn xóa không?')" OnClick="Delete_Click" runat="server" Text="Xóa" BackColor="#ff1a1a" BorderColor="#ff1a1a" CssClass="btn btn-primary ml-2" />
        </div>

        <div class="mt-3">
            <h5>Danh sách loại phản ánh</h5>
            <table class="table table-striped table-hover table-bordered">
                <thead>
                    <tr>
                        <th class="text-center" scope="col">
                            <input id="selectAll" type="checkbox"><label for='selectAll'></label></th>
                        <th class="text-center" scope="col">ID</th>
                        <th class="text-center" scope="col">Tên Loại</th>

                    </tr>
                </thead>
                <tbody>
                    <% foreach (var reflectType in reflectTypes)
                        { %>
                    <tr>
                        <td style="width: 40px; text-align: center">
                            <input name='cbID' value='<%=reflectType.ReflectTypeID %>' type='checkbox' /></td>
                        <td class="text-center"><%= reflectType.ReflectTypeID %></td>
                        <td class="text-center"><%= reflectType.Name %></td>
                        <td class="text-center">
                            <a href="?idEdit=<%=reflectType.ReflectTypeID %>&page=<%=this.pivot%>">Sửa</a>
                        </td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
            <div class="card-footer text-right" style="padding-right: 550px">
                <asp:Panel ID="pnPhanTrang" runat="server">
                    <div class="row">
                        <div class="col-auto">
                            <asp:Button ID="btTruoc" runat="server" Text="Trước" BackColor="#339933" BorderColor="#339933" class="btn btn-primary" href="?page=<%=this.pivot%>" OnClick="btPhanTrang_Click" />
                        </div>
                        <div class="col-auto">
                            <asp:HiddenField ID="hPageIndex" runat="server" />
                            <asp:HiddenField ID="hTotalRows" runat="server" />
                            <asp:HiddenField ID="hPageSize" runat="server" />
                            <asp:Panel ID="pnButton" runat="server"></asp:Panel>
                        </div>
                        <div class="col-auto">
                            <asp:Button ID="btSau" runat="server" Text="Sau" BackColor="#339933" BorderColor="#339933" class="btn btn-primary" href="?page=<%=this.pivot%>" OnClick="btPhanTrang_Click" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>

        </div>
    <script>
        $("#selectAll").click(function () {
            $("input[type=checkbox]").prop('checked', $(this).prop('checked'));
        });
    </script>
</asp:Content>
