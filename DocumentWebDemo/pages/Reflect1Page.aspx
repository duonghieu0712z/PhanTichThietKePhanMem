<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reflect1Page.aspx.cs" Inherits="DocumentWebDemo.pages.Reflect1Page" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../CSS/styles.css" rel="stylesheet" type="text/css" />
    <h1 style="text-align: center; color: #008000; font-weight: bold;" class="my-3">Quản lý phản ánh người dùng</h1>
        <div class="container p-3 mx-auto">
         <div class="col-md-1" >
                    <asp:DropDownList style="height: 40px; width :80px; background :#b6ff00" CssClass="custom-select" AutoPostBack="true" ID="dlPageNumber" runat="server" OnSelectedIndexChanged="dlPageNumber_SelectedIndexChanged">
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>100</asp:ListItem>
                        <asp:ListItem>150</asp:ListItem>
                        <asp:ListItem>200</asp:ListItem>
                        <asp:ListItem>250</asp:ListItem>
                        <asp:ListItem>300</asp:ListItem>
                        <asp:ListItem>350</asp:ListItem>
                        <asp:ListItem>400</asp:ListItem>
                        <asp:ListItem>450</asp:ListItem>
                        <asp:ListItem>500</asp:ListItem>
                        <asp:ListItem>1000</asp:ListItem>
                    </asp:DropDownList>
                </div>
        </div>
    <div class="dnnFormItem">
        <div class="  d-flex row align-items-center">
            <label for="ReflectID" class="col-3 m-0">ID phản ánh</label>
            <input style="background: #f1f1f1;" id="ReflectID" type="text" readonly class="form-control col-8" placeholder="ID phản ánh" runat="server">
        </div>
        <div class=" d-flex row align-items-center mt-2">
            <label for="phananhlist" class="col-3 m-0">Phản Ánh</label>
            <asp:DropDownList ID="phananhlist" runat="server" CssClass="form-control col-8"></asp:DropDownList>
        </div>
        <div class=" d-flex row align-items-center mt-2">

            <label for="tieude" class="col-3 m-0">Tiêu đề</label>
            <input id="tieude" type="text" class="form-control col-8" placeholder="Nhập vào tiêu đề phản ánh" runat="server" min="1">
        </div>

        <div class="  d-flex row align-items-center mt-2">
            <asp:Label CssClass="col-3 m-0" ID="Label3" runat="server" Text="Số điện thoại"></asp:Label>
            <input type="text" class="form-control col-8" id="sdt" runat="server" placeholder="">
        </div>

        <div class=" d-flex row align-items-center mt-2">
            <label for="gmail" class="col-3 m-0">Email</label>
            <input id="gmail" type="text" class="form-control col-8" placeholder="Nhập vào email" runat="server">
        </div>

        <div class=" d-flex row align-items-center mt-2">
            <label for="hoten" class=" col-3 m-0">Họ Tên</label>
            <input id="hoten" type="text" class="form-control col-8" placeholder="Nhập vào họ và tên" runat="server">
        </div>
        <div class=" d-flex row align-items-center mt-2">
            <label for="noidung" class=" col-3 m-0">Nội dung</label>
            <input id="noidung" type="text" class="form-control col-8" placeholder="Nhập vào nội dung" runat="server">
        </div>
        <div class=" d-flex row align-items-center mt-2">
            <label for="linkvideo" class=" col-3 m-0">Link Video</label>
            <asp:Image ID="anh" runat="server" ImageUrl='<%# "~/images/"+Eval("anh") %>' />
            <input id="linkvideo" type="text" class="form-control col-8" placeholder="Nhập vào link video" runat="server">
        </div>
        <div class=" d-flex row align-items-center mt-2">
            <label for="trangthai" class=" col-3 m-0">Trạng thái</label>
            <input id="trangthai" type="text" class="form-control col-8" readonly placeholder="Nhập vào trạng thái" runat="server">
        </div>
        <div class="d-flex row mt-2">
            <asp:Label CssClass="col-3 m-0" ID="Label6" runat="server" Text="Nội dung phản hồi"></asp:Label>
            <textarea class="col-8" id="txtContent" cols="20" rows="17" runat="server"></textarea>
        </div>
    </div>






    <div class="d-flex justify-content-center align-items-center mt-2">
            <%--<asp:Button ID="AddBusButton" runat="server" OnClick="AddBusButton_Click" Text="Thêm Mới" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary" OnClientClick="" />--%>
            <asp:Button ID="UpdateBusButton" runat="server" href="?page=<%=this.pivot%>" OnClick="Button2_Click" Text="Phản Hồi" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary ml-2" />
            <asp:Button ID="Clear" runat="server" OnClick="Clear_Click" Text="Mặc định" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary ml-2" />
           <%-- <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Phản Hồi" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary ml-2" />--%>
            <asp:Button ID="Button1" runat="server" OnClick="DeleteBusButton_CLick" Text="Xóa" BackColor="#ff1a1a" OnClientClick="return confirm('Bạn có muốn xóa không?')" BorderColor="#ff1a1a" CssClass="btn btn-primary ml-2" />
    </div>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <div class="mt-3">
        <div class="d-flex align-items-center justify-content-between mb-2">
            <h5>Danh sách phản ánh :</h5>
            <div class="col  d-flex row align-items-center justify-content-end">
                <input id="txtKeyword" type="text" placeholder="Nhập từ khóa tìm kiếm" class="mr-2" runat="server" />
                <asp:Button ID="Search" runat="server" href="?page=<%=this.pivot%>" OnClick="Search_Click" Text="Tìm kiếm" BackColor="#339933" BorderColor="#339933" CssClass="btn btn-primary" />
            </div>
        </div>


        <contenttemplate>
            <asp:Panel ID="pnTable" runat="server">
                <table class="table table-striped table-hover table-bordered" style="padding-left: 400px">
                    <thead>
                        <tr>
                            <th class="text-center" scope="col">
                                <input id="selectAll" type="checkbox"><label for='selectAll'></label></th>
                            <th class="text-center" scope="col">ID</th>
                            <th class="text-center" scope="col">ID loại phản ánh</th>
                            <th class="text-center" scope="col">Tiêu Đề</th>
                            <th class="text-center" scope="col">Số Điện Thoại</th>
                            <th class="text-center" scope="col">Email</th>
                            <th class="text-center" scope="col">Họ Và Tên</th>
                            <th class="text-center" scope="col">Nội Dung</th>
                            <th class="text-center" scope="col">Link Video</th>
                            <th class="text-center" scope="col">Trạng Thái</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% foreach (var phananh in listPhanAnh)
                            { %>
                        <tr>
                            <td style="width: 40px; text-align: center">
                                <input name='cbID' value='<%=phananh.ID %>' type='checkbox' /></td>
                            <th class="text-center" scope="row"><%= phananh.ID %></th>
                            <th class="text-center" scope="row"><%= phananh.ReflectTypeID %></th>
                            <td class="text-center"><%= phananh.Title %></td>
                            <td class="text-center"><%= phananh.PhoneNumber %></td>
                            <td class="text-center"><%= phananh.Email %></td>
                            <td class="text-center"><%= phananh.FullName %></td>
                            <td class="text-center"><%= phananh.Content %></td>
                            <td class="text-center">
                                <img style="width: 100px" src="<%=phananh.VideoOrPicture %>" /></td>
                            <td class="text-center"><%= phananh.Status %></td>
                            <td class="text-center">
                                <a href="?idEdit=<%=phananh.ID %>&page=<%=this.pivot%>">Phản hồi</a>
                            </td>

                        </tr>
                        <% } %>
                    </tbody>
                </table>
            </asp:Panel>
        </contenttemplate>
        <div class="card-footer " style="padding-right: 350px">
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
