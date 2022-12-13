<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResponsibleUnitPage.aspx.cs" Inherits="Web.Pages.ResponsibleunitPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../CSS/Responsible.css" rel="stylesheet" type="text/css" />
    <h2 class="text-light border-0 mt-4" style="font-family: monospace; font-weight: 800; font-size: 32px">Đơn vị đảm nhận</h2>

    <button class="btn1 btn btn-primary mb-2" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">Thêm đơn vị đảm nhận</button>
    <div class="collapse formAdd bg-light rounded" id="collapseExample">
        <asp:Panel CssClass="panel1 mt-3 p-4" ID="Panel1" runat="server">
            <label class="form-control" style="background-color: #DADADADA; font-weight: 600">Thêm đơn vị đảm nhận</label>
            <div class="form-group border">
                <div class="col">
                    <div class="row mt-4 px-4">
                        <div class="col">
                            <input type="text" class="form-control" id="txtID" readonly runat="server" placeholder="ID" />
                        </div>
                    </div>

                    <div class="row mt-4 px-4">
                        <div class="col">
                            <input type="text" class="form-control" id="txtResbonsilbeName" runat="server" placeholder="Tên đơn vị đảm nhận" />
                        </div>
                    </div>

                    <div class="row mt-4 px-4">
                        <div class="col">
                            <input type="text" class="form-control" id="txtPhoneNumber" runat="server" placeholder="Số điện thoại" />
                        </div>
                    </div>
                    <div class="row mt-4 px-4">
                        <div class="form-group mt-2">
                            <asp:Button ID="btLuu" runat="server" Text="Lưu" CssClass="btn btn-success" OnClick="btLuu_Click1" />
                            <asp:Button ID="btnClear" runat="server" Text="Xóa" CssClass="btn btn-danger" OnClick="btnClear_Click1" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>

    <!-- Tables -->
    <div class="table_panel bg-light mb-3 rounded">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel  CssClass="mt-2 px-5 py-3" ID="pnTable" runat="server">
                    <div class="row ml-4">
                        <table class="table table-bordered">
                            <label class="form-control" style="background-color: #DADADADA; font-weight: 600">
                                Danh sách đơn vị đảm nhận</label>
                            <div class="mt-2 mb-2 p-0 d-flex gap-2 w-50">
                                <div class="col w-50">
                                    <input placeholder="Tìm kiếm" runat="server" id="txtSearch" class="form-control" />
                                </div>
                                <asp:DropDownList CssClass="btnDrop btn btn-secondary bg-light dropdown-item w-25 border" AutoPostBack="true" ID="drlPageNumber" runat="server" OnSelectedIndexChanged="dlPageNumber_SelectedIndexChanged">
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="btTim" runat="server" CssClass="btn1 btn btn-success" Text="Tìm" OnClick="btTim_Click" />
                                <asp:Button ID="btnXoa" runat="server" Text="Xóa" CssClass="btn btn-danger ml-2" OnClick="btnXoa_Click" />
                            </div>
                            <thead>
                                <tr class="text-center text-nowrap" style="background-color: #DADADADA">
                                    <th>
                                        <input id="selectAll" type="checkbox"><label for="selectAll"></label></input></th>
                                    <th>Edit</th>
                                    <th>ID</th>
                                    <th>Tên đơn vị đảm nhận</th> 
                                    <th>Số điện thoại</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in ls)
                                    {
                                %>
                                <tr>
                                    <td style="width: 40px;">
                                        <input name='cbID' type='checkbox' value='<%= item.ResponsibleUnitID %>' />
                                    </td>
                                    <td style="width: 50px"><a class="btn btn-primary" href="?idedit=<%=item.ResponsibleUnitID %>" style="text-align: center">Edit</a> </td>
                                    <td><%=item.ResponsibleUnitID %></td>
                                    <td><%=item.ReponsibleUnitName %></td>
                                    <td><%=item.PhoneNumber %></td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
                    
        <div class="card-footer text-right">
            <asp:Panel ID="pnPhanTrang" runat="server" CssClass="pb-5">
                <div class="form-row d-flex justify-content-center">
                    <div class="col-auto">
                        <asp:Button ID="btTruoc" runat="server" Text="Trước" class="btn btn-success" OnClick="btPhanTrang_Click" />
                    </div>
                    <div class="d-flex col-auto px-4">
                        <asp:HiddenField ID="hPageIndex" runat="server" />
                        <asp:HiddenField ID="hTotalRows" runat="server" />
                        <asp:HiddenField ID="hPageSize" runat="server" />
                        <asp:Panel ID="pnButton" runat="server"></asp:Panel>
                    </div>
                    <div class="col-auto">
                        <asp:Button ID="btSau" runat="server" Text="Sau" class="btn  btn-success" OnClick="btPhanTrang_Click" />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>

    <script>
        $("#selectAll").click(function () {
            $("input[type=checkbox]").prop('checked', $(this).prop('checked'));
        })

        $("#btnLuu").click(function () {
            $('.collapse').collapse('show')
        })

        $(".btn-edit").click(function () {
            event.preventDefault();
            $('.collapse').collapse('show')
        })

        $(".btn-clear").click(function () {
            event.preventDefault();
            $('.collapse').collapse('show')
        })
    </script>
</asp:Content>
