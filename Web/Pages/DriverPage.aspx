<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DriverPage.aspx.cs" Inherits="Web.Pages.DriverPage" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: #F4F9F6; min-height: 100vh; box-shadow: 0px 6px 15px rgba(0,0,0,0.15); border-radius: 15px">

        <h2 style="text-align: center; color: #8D7F7F; font-weight: bold; padding-top: 20px" class="mt-3">QUẢN LÝ THÔNG TIN TÀI XẾ</h2>
        <div class="card">
            <div class="card-header">
                <div class="form-row d-flex justify-content-end">
                    <div class="col-md-1">
                        <asp:DropDownList CssClass="form-control dropdown-toggle bg-white text-dark border rounded" AutoPostBack="true" ID="dlPageNumber" runat="server" OnSelectedIndexChanged="dlPageNumber_SelectedIndexChanged">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <input type="text" class="form-control" id="txtKeyword" placeholder="Keyword" runat="server">
                    </div>
                    <div class="cod-md-2">
                        <asp:Button ID="btTim" runat="server" CssClass="btn btn-primary" Text="Tìm" OnClick="btTim_Click" />
                    </div>
                    <div class="cod-md-2">
                        &nbsp;<asp:Button ID="btThemMoi" CssClass="btn btn-primary" runat="server" Text="Thêm mới" OnClick="btThemMoi_Click" />
                    </div>
                    <div class="cod-md-2">
                        &nbsp;<asp:Button ID="btXoa" runat="server" CssClass="btn btn-primary" Text="Xóa" OnClientClick="return confirm('Bạn có muốn xóa không?')" OnClick="btXoa_Click" />
                    </div>
                </div>
            </div>
            <div class="card-body">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

                <!-- Controls -->
                <asp:Panel ID="pnControls" runat="server" Visible="false">
                    <div style="background: #ffffff; box-shadow: 0px 6px 15px rgba(0,0,0,0.15); border-radius: 5px; margin: 0 10px; padding: 20px;">
                        <div style="padding: 10px;" class="flex">
                            <div class="row">
                                <div class="col-3">
                                    <input type="text" class="form-control" id="txtID" readonly runat="server" placeholder="ID">
                                </div>
                                <div class="col-4">
                                    <input type="text" class="form-control" id="txtName" runat="server" placeholder="Tên tài xế">
                                </div>
                                <div class="col-4">
                                    <input type="text" class="form-control" id="txtIDCard" runat="server" placeholder="CCCD">
                                </div>
                            </div>
                            <div class="row mt-3 gap-3">
                                <div class="col-3">
                                    <input type="date" class="form-control col" id="txtDayOfBirth" runat="server" placeholder="Ngày sinh">
                                </div>
                                <asp:DropDownList ID="drSex" CssClass="col-3 dropdown-toggle bg-white text-dark w-25 border rounded" runat="server">
                                    <asp:ListItem>Nam</asp:ListItem>
                                    <asp:ListItem>Nữ</asp:ListItem>
                                </asp:DropDownList>
                                <div class="col flex row">
                                    <p runat="server" id="lablebus" class="col-4">Xe tài xế sử dụng:</p>
                                    <div class="col">
                                        <asp:DropDownList ID="drDriverBus" CssClass="col-1 dropdown-toggle bg-white text-dark w-25 border rounded" runat="server">
                                        </asp:DropDownList>
                                    </div>

                                </div>

                            </div>
                            <div class="row mt-3">
                                <div class="col-8">
                                    <input type="text" class="form-control" id="txtHomeTown" runat="server" placeholder="Quê Quán">
                                </div>

                            </div>
                            <div class="col-6">
                            </div>
                        </div>
                    </div>

                    <div class="form-group mt-3">
                        <asp:Button ID="btXoaTrang" runat="server" Text="Xóa trắng" CssClass="btn btn-primary" OnClick="btXoaTrang_Click" />
                        <asp:Button ID="btLuu" runat="server" Text="Lưu" CssClass="btn btn-primary" OnClick="btLuu_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Cập nhập" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btThoat" runat="server" Text="Thoát" CssClass="btn btn-primary" OnClick="btThoat_Click" />
                    </div>

                </asp:Panel>

                <!-- Tables -->
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnTable" runat="server">
                            <div style="background-color: #ffffff; box-shadow: 0px 6px 15px rgba(0,0,0,0.15); border-radius: 15px;" class="table-responsive">

                                <div class="table-responsive">
                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th>
                                                    <input id="selectAll" type="checkbox"><label for='selectAll'></label></th>
                                                <th>Edit</th>
                                                <th>Tên tài xế</th>
                                                <th>Xe</th>
                                                <th>Giới tính</th>
                                                <th>ID Card</th>
                                                <th>Ngày sinh</th>
                                                <th>Quê Quán</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <%foreach (var item in ls)
                                                {
                                                    ls1 = BusinessLayer.Functions.HRFunctions.Instance.Select_BusOfDriver_ID(item.DriverID);%>
                                            <tr>
                                                <td style="width: 40px; text-align: center">
                                                    <input name='cbID' value='<%=item.DriverID %>' type='checkbox' /></td>
                                                <td style="width: 50px">
                                                    <a style="text-align: center" href="?idEdit=<%=item.DriverID %>" class="btn btn-primary">Edit</a>
                                                </td>
                                                <td><%=item.FullName %></td>
                                                <% if (this.ls1 != null)
                                                    {
                                                %>
                                                <td><%= this.ls1.BusID%></td>
                                                <%} %>

                                                <%
                                                    else
                                                    {
                                                %>
                                                <td>Vui lòng cập nhập</td>
                                                <%} %>
                                                <td><%=this.Sex(item.Sex)%></td>
                                                <td><%=item.IDCard %></td>
                                                <td><%=item.DayOfBirth %></td>
                                                <td><%=item.HomeTown %></td>
                                            </tr>
                                            <% } %>
                                        </tbody>
                                    </table>

                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <div class="card-footer text-right">
                <asp:Panel ID="pnPhanTrang" runat="server">
                    <div class="row">
                        <div class="col-auto">
                            <asp:Button ID="btTruoc" runat="server" Text="Trước" class="btn btn-dark" OnClick="btPhanTrang_Click" />
                        </div>
                        <div class="col-auto">
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


            <script>
                $("#selectAll").click(function () {
                    $("input[type=checkbox]").prop('checked', $(this).prop('checked'));

                });
            </script>
        </div>
</asp:Content>
