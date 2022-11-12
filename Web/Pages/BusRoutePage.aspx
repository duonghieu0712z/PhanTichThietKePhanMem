<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusRoutePage.aspx.cs" Inherits="Web.Pages.BusRoutePage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../CSS/RouteMgmt.css" rel="stylesheet" type="text/css" />
    <h1 class="text-light border-0 mt-4" style="font-family: monospace; font-weight: 800; font-size: 32px">Quản lý tuyến
    </h1>

    <asp:Button ID="btnOpenFormAdd" runat="server" Text="Thêm tuyến mới" CssClass="btn_AddNewRoute p-2 mt-5" OnClick="btnOpenFormAdd_Click1" />
    <div class="formAdd bg-light">
        <asp:Panel CssClass="panel1 mt-3 p-4" ID="Panel1" runat="server" Visible="false">
            <label class="form-control" style="background-color: #DADADADA; font-weight: 600">Thêm tuyến</label>
            <div class="form-group border">

                <div class="row mt-4 px-4">
                    <div class="col">
                        <input type="text" class="form-control" id="txtID" readonly runat="server" placeholder="ID" />
                    </div>
                    <div class="col">
                        <input type="text" class="form-control" id="txtRouteNumber" runat="server" placeholder="Mã số tuyến" />
                    </div>
                </div>

                <div class="row mt-4 px-4">
                    <div class="col">
                        <input type="text" class="form-control" id="txtRouteName" runat="server" placeholder="Tên tuyến" />
                    </div>
                    <div class="col">
                        <asp:DropDownList CssClass="custom-select form-control" ID="ddlResponsibleUnit" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row mt-4 px-4">
                    <div class="col">
                        <input type="text" class="form-control" id="txtOperationType" runat="server" placeholder="Loại hình hoạt động" />

                    </div>
                    <div class="col">
                        <input type="text" class="form-control" id="txtOperationTime" runat="server" placeholder="Thời gian hoạt động" />
                    </div>
                </div>

                <div class="row mt-4 px-4">
                    <div class="col">
                        <input type="text" class="form-control" id="txtFare" runat="server" placeholder="Giá vé" />
                    </div>
                    <div class="col">
                        <input type="text" class="form-control" id="txtBusesAmount" runat="server" placeholder="Số chuyến" />
                    </div>
                </div>

                <div class="row mt-4 px-4">
                    <div class="col">
                        <input type="text" class="form-control" id="txtBusesTime" runat="server" placeholder="Thời gian chuyến" />
                    </div>

                    <div class="col">
                        <input type="text" class="form-control" id="txtBusesSpace" runat="server" placeholder="Giãn cách chuyến" />
                    </div>
                </div>
                <div class="form-group mt-3 p-4">
                    <asp:Button ID="btLuu" runat="server" Text="Lưu" CssClass="btn" />
                    <asp:Button ID="btnCancelFormAdd" runat="server" Text="Thoát" CssClass="btn" OnClick="btnCancelFormAdd_Click1" />
                </div>
            </div>

        </asp:Panel>
    </div>
    <!-- Tables -->
    <div class="table_panel bg-light mb-3">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel CssClass=" mt-2 px-5 py-3" ID="pnTable" runat="server">
                    <div class="row ml-4" >
                        <table class="table table-bordered table-responsive bg-light" >
                            <label class="form-control" style="background-color: #DADADADA; font-weight: 600">
                                Danh sách tuyến</label>

                            <div class="mt-2 mb-2 row d-flex">

                                <div class="col">
                                    <input id="txtKeyword" runat="server" class="form-control" placeholder="Tìm kiếm" type="text" />
                                </div>
                                <div class="col">
                                    <asp:DropDownList ID="drlPageNumber" runat="server" AutoPostBack="true" CssClass="dropdown-item form-control" OnSelectedIndexChanged="drlPageNumber_SelectedIndexChanged">
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col">
                                    <asp:Button ID="btTim" runat="server" CssClass="btn btn-primary" Text="Tìm" />
                                </div>
                                <div class="col">
                                    <asp:Button ID="btXoa" runat="server" CssClass="btn btn-primary" OnClick="btXoa_Click" OnClientClick="return confirm('Bạn có muốn xóa không?')" Text="Xóa" />
                                </div>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </div>
                            <thead class="table-secondary">
                                <tr class="text-center text-nowrap">
                                    <th>
                                        <input id="selectAll" type="checkbox"><label for="selectAll"></label></input></th>
                                    <th>Edit</th>
                                    <th>Mã tuyến</th>
                                    <th>Tên tuyến</th>
                                    <th>Loại hình HĐ</th>
                                    <th>Thời gian HĐ</th>
                                    <th>Giá vé</th>
                                    <th>Số chuyến</th>
                                    <th>Thời gian chuyến</th>
                                    <th>Giãn cách chuyến</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var item in ls)
                                    { %>
                                <tr>
                                    <td style="width: 40px; text-align: center">
                                        <input name='cbID' type='checkbox' value='<%=item.BusRouteID %>' />
                                    </td>
                                    <td style="width: 50px"><a class="btn btn-primary" href="?idEdit=<%=item.BusRouteID %>" style="text-align: center">Edit</a> </td>
                                    <td><%=item.RouteNumber %></td>
                                    <td><%=item.RouteName %></td>
                                    <td><%=item.OperationType %></td>
                                    <td><%=item.OperationTime %></td>
                                    <td><%=item.Fare %></td>
                                    <td><%=item.BusesAmount %></td>
                                    <td><%=item.BusesTime %></td>
                                    <td><%=item.BusesSpace %></td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="card-footer text-right">
            <asp:Panel ID="pnPhanTrang" runat="server" CssClass="p-4">
                <div class="form-row d-flex justify-content-center">
                    <div class="col-auto">
                        <asp:Button ID="btTruoc" runat="server" Text="Trước" class="btn btn-dark" OnClick="btPhanTrang_Click" />
                    </div>
                    <div class="col-auto px-4">
                        <asp:HiddenField ID="hPageIndex" runat="server" />
                        <asp:HiddenField ID="hTotalRows" runat="server" />
                        <asp:HiddenField ID="hPageSize" runat="server" />
                        <asp:Panel ID="pnButton" runat="server"></asp:Panel>
                    </div>
                    <div class="col-auto">
                        <asp:Button ID="btSau" runat="server" Text="Sau" class="btn  btn-dark" OnClick="btPhanTrang_Click" />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
    <script>
        $("#selectAll").click(function () {
            $("input[type=checkbox]").prop('checked', $(this).prop('checked'));
        })
    </script>
</asp:Content>
