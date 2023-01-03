<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BusPage.aspx.cs" Inherits="Web.Pages.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="text-align: center; color: #008000; font-weight: bold;" class="mt-3">Quản lý xe buýt</h1>
    <%--<div>
        <div style="background: #f1f1f1; padding: 20px;">
            <h4>Thêm, sửa và xóa xe: </h4>
            <div class="row">
                <div class="col-6">
                    <asp:Label runat="server" Width="100px">ID của xe :</asp:Label><asp:DropDownList ID="BusList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="BusList_SelectedIndexChanged" Width="200px" Height="24px"></asp:DropDownList><br />
                </div>
                <div class="col-6">
                    <asp:Label runat="server" Width="100px">Biển số xe :</asp:Label><asp:TextBox ID="BienSoXe" runat="server" Width="200px"></asp:TextBox><br />
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <asp:Label runat="server" Width="100px">Số của xe :</asp:Label><asp:TextBox ID="SoXe" runat="server" Width="200px"></asp:TextBox><br />
                </div>
                <div class="col-6">
                    <asp:Label runat="server" Width="100px">Số chổ ngồi :</asp:Label><asp:TextBox ID="SoChoNgoi" runat="server" Width="200px"></asp:TextBox><br />
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <asp:Label runat="server" Width="100px">Trạng thái :</asp:Label><asp:TextBox ID="TrangThai" runat="server" Width="200px"></asp:TextBox><br />
                </div>
                <div class="col-6">
                    <asp:Label runat="server" Width="100px">Loại xe :</asp:Label><asp:DropDownList ID="bustypelist" runat="server" Width="200px" Height="24px"></asp:DropDownList><br />
                </div>
            </div>
            <div class="row">
                <asp:Label runat="server" Width="100px">Tuyến :</asp:Label><asp:DropDownList ID="tuyenlist" runat="server" Width="200px" Height="24px"></asp:DropDownList><br />
            </div>


            <asp:Button ID="AddBusButton" runat="server" Text="Thêm Xe" OnClick="AddBusButton_Click" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary" />
            <asp:Button ID="UpdateBusButton" runat="server" Text="Sửa Xe" OnClick="UpdateBusButton_Click" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary" />
            <asp:Button ID="DeleteBusButton" runat="server" Text="Xóa Xe" OnClick="DeleteBusButton_CLick" BackColor="red" BorderColor="red" CssClass="btn btn-primary" />
        </div>
        <hr />
        <table class="table table-primary caption-top table-striped table-hover table-bordered">
            <caption class="text-center">DANH SÁCH XE BUÝT</caption>
            <thead>
                <tr>
                    <th class="text-center" scope="col">ID</th>
                    <th class="text-center" scope="col">Biến Số Xe</th>
                    <th class="text-center" scope="col">Số Của Xe</th>
                    <th class="text-center" scope="col">Số Chỗ Ngồi</th>
                    <th class="text-center" scope="col">Trạng Thái</th>
                    <th class="text-center" scope="col">Loại Xe</th>
                    <th class="text-center" scope="col">Tuyến</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var bus in listBus)
                    { %>
                <tr>
                    <th class="text-center" scope="row"><%= bus.BusID %></th>
                    <td><%= bus.LicensePlates %></td>
                    <td><%= bus.BusNumber %></td>
                    <td><%= bus.SumSeats %></td>
                    <td><%= bus.Status %></td>
                    <td><%= bus.BusTypeID %></td>
                    <td><%= bus.RoutesID %></td>
                </tr>
                <% } %>
            </tbody>
        </table>
    </div>--%>
    <div class="container mt-3">
        <div class="row mb-3">
            <div class="col">
                <div class="row align-items-center">
                    <label for="BusID" class="form-label col-3">ID xe buýt</label>
                    <input style="background: #f1f1f1;" id="BusID" type="text" readonly class="form-control col" placeholder="ID Xe Buýt" runat="server">
                </div>
            </div>
            <div class="col">
                <div class="row align-items-center">
                    <label for="BienSoXe" class="form-label col-3">Biển số xe</label>
                    <input id="BienSoXe" type="text" class="form-control col" placeholder="Nhập vào biển số xe" runat="server" title="" pattern="[0-9]{2}[A-Z]{1}[-]{1}[0-9]{5}">
                </div>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col">
                <div class="row align-items-center">
                    <label for="SoXe" class="form-label col-3">Số của xe</label>
                    <input id="SoXe" type="number" class="form-control col" placeholder="Nhập vào số của xe" runat="server" min="1">
                </div>
            </div>
            <div class="col">
                <div class="row align-items-center">
                    <label for="SoChoNgoi" class="form-label col-3">Số chỗ ngồi</label>
                    <input id="SoChoNgoi" type="number" class="form-control col" placeholder="Nhập vào số chỗ ngồi" runat="server" min="4" max="40">
                </div>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col">
                <div class="row align-items-center">
                    <label for="TrangThai" class="form-label col-3">Trạng thái</label>
                    <input id="TrangThai" type="text" class="form-control col" placeholder="Nhập vào trạng thái" runat="server">
                </div>
            </div>
            <div class="col">
                <div class="row align-items-center">
                    <label for="bustypelist" class="form-label col-3">Loại xe</label>
                    <asp:DropDownList ID="bustypelist" runat="server" CssClass="form-select col"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-6">
                <div class="row align-items-center">
                    <label for="tuyenlist" class="form-label col-3">Tuyến</label>
                    <asp:DropDownList ID="tuyenlist" runat="server" CssClass="form-select col"></asp:DropDownList>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col">
            <asp:Button ID="AddBusButton" runat="server" OnClick="AddBusButton_Click" Text="Thêm Mới" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary" OnClientClick="" />
            <asp:Button ID="UpdateBusButton" runat="server" href="?page=<%=this.pivot%>" OnClick="UpdateBusButton_Click" Text="Cập Nhật" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary" />
            <asp:Button ID="Button1" runat="server" OnClick="DeleteBusButton_CLick" Text="Xóa" BackColor="#ff1a1a" OnClientClick="return confirm('Bạn có muốn xóa không?')" BorderColor="#ff1a1a" CssClass="btn btn-primary" />
        </div>
        <div class="col d-flex justify-content-end">
            <asp:Button ID="Clear" runat="server" OnClick="Clear_Click" Text="Mặc định" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary me-2" />
            <asp:Button ID="Search" runat="server" href="?page=<%=this.pivot%>" OnClick="Search_Click" Text="Tìm kiếm" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary" />
        </div>
    </div>

    <div class="mt-3">
        <h5>Danh sách xe buýt:</h5>
        <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr>
                    <th class="text-center" scope="col">
                        <input id="selectAll" type="checkbox"><label for='selectAll'></label></th>
                    <%--<th class="text-center" scope="col">ID</th>--%>
                    <th class="text-center" scope="col">Biến Số Xe</th>
                    <th class="text-center" scope="col">Số Của Xe</th>
                    <th class="text-center" scope="col">Số Chỗ Ngồi</th>
                    <th class="text-center" scope="col">Trạng Thái</th>
                    <th class="text-center" scope="col">Loại Xe</th>
                    <th class="text-center" scope="col">Tuyến</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var bus in listBus)
                    { %>
                <tr>
                    <td style="width: 40px; text-align: center">
                        <input name='cbID' value='<%=bus.BusID %>' type='checkbox' /></td>
                    <%--<th class="text-center" scope="row"><%= bus.BusID %></th>--%>
                    <td class="text-center"><%= bus.LicensePlates %></td>
                    <td class="text-center"><%= bus.BusNumber %></td>
                    <td class="text-center"><%= bus.SumSeats %></td>
                    <td class="text-center"><%= bus.Status %></td>
                    <td class="text-center"><%= this.Get_BusTypeName(bus.BusTypeID) %></td>
                    <td class="text-center"><%= this.Get_BusRouteName(bus.RoutesID) %></td>
                    <td class="text-center">
                        <a href="?idEdit=<%=bus.BusID %>&page=<%=this.pivot%>">Sửa</a>
                    </td>
                </tr>
                <% } %>
            </tbody>
        </table>
        <div class="card-footer text-right">
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
        <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
    </div>

    <script>
        $("#selectAll").click(function () {
            $("input[type=checkbox]").prop('checked', $(this).prop('checked'));
        });
    </script>
</asp:Content>
