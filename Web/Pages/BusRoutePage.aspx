<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusRoutePage.aspx.cs" Inherits="Web.Pages.BusRoutePage" EnableEventValidation="false"%>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../CSS/RouteMgmt.css" rel="stylesheet" type="text/css" />
    <h1 class="text-light border-0 mt-4" style="font-family: monospace; font-weight: 800; font-size: 32px">Quản lý tuyến
    </h1>

    <button class="btn1 btn btn-primary mb-2" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">Thêm tuyến</button>
    <div class="collapse formAdd bg-light rounded" id="collapseExample">
        <asp:Panel CssClass="panel1 mt-3 p-4" ID="Panel1" runat="server">
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
                <asp:Label ID="error" runat="server" Text=""></asp:Label>
                <div class="form-group mt-3 p-4">
                    <asp:Button ID="btLuu" runat="server" Text="Lưu" CssClass="btn" OnClick="btLuu_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Xóa" CssClass="btn-clear btn btn-danger" OnClick="btnClear_Click" />
                </div>
            </div>

        </asp:Panel>
    </div>
    <!-- Tables -->
    <div class="table_panel bg-light mb-3 rounded">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel CssClass=" mt-2 px-5 py-3" ID="pnTable" runat="server">
                    <div class="row ml-4">
                        <label class="form-control" style="background-color: #DADADADA; font-weight: 600">
                            Danh sách tuyến</label>

                        <div class="mt-2 mb-2 p-0 d-flex gap-2 w-50">
                            <div class="col w-50">
                                <input id="txtKeyword" runat="server" class="form-control" placeholder="Tìm kiếm" type="text" />
                            </div>
                            <asp:DropDownList ID="drlPageNumber" runat="server" AutoPostBack="true" CssClass="btn btn-secondary bg-light dropdown-item w-25 border text-dark" OnSelectedIndexChanged="drlPageNumber_SelectedIndexChanged">
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                            </asp:DropDownList>
                            <div class="">
                                <asp:Button ID="btTim" runat="server" CssClass="btn1 btn btn-primary" Text="Tìm" OnClick="btTim_Click"/>
                            </div>
                            <div class="">
                                <asp:Button ID="btXoa" runat="server" CssClass="btn btn-danger" OnClick="btXoa_Click" OnClientClick="return confirm('Bạn có muốn xóa không?')" Text="Xóa" />
                            </div>
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </div>
                        <table class="table table-bordered table-responsive bg-light">
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
            <asp:Panel ID="pnPhanTrang" runat="server" CssClass="pb-5">
                <div class="form-row d-flex justify-content-center">
                    <div class="col-auto">
                        <asp:Button ID="btTruoc" runat="server" Text="Trước" CssClass="btn btn-primary" OnClick="btPhanTrang_Click" />
                    </div>
                    <div class="d-flex col-auto px-4">
                        <asp:HiddenField ID="hPageIndex" runat="server" />
                        <asp:HiddenField ID="hTotalRows" runat="server" />
                        <asp:HiddenField ID="hPageSize" runat="server" />
                        <asp:Panel ID="pnButton" runat="server"></asp:Panel>
                    </div>
                    <div class="col-auto">
                        <asp:Button ID="btSau" runat="server" Text="Sau" CssClass="btn btn-primary" OnClick="btPhanTrang_Click" />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
    <script>
        $("#selectAll").click(function () {
            $("input[type=checkbox]").prop('checked', $(this).prop('checked'));
        })
        $(".btn-edit").click(function () {
            event.preventDefault();
            $('.formAdd').collapse('show')
        })
        $(".btn-clear").click(function () {
            event.preventDefault();
            $('.formAdd').collapse('show')
        })
    </script>
</asp:Content>