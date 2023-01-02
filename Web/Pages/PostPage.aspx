<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostPage.aspx.cs" Inherits="Web.Pages.PostPage" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="text-dark border-0 mt-4" style="font-family: monospace; font-weight: 800; font-size: 32px">Quản lý bài viết
    </h1>
    <button class="btn btn-secondary mb-3" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">Thêm bài viết </button>
    <div class="collapse" id="collapseExample">
        <div class="formAdd bg-light d-flex col gap-5">
            <asp:Panel CssClass="panel border border-2 rounded w-100" ID="Panel1" runat="server">


                <div class=" form-group px-5 py-3 d-flex row gap-3">
                    <input type="text" class="form-control" id="txtID" readonly runat="server" placeholder="ID" />
                    <input type="text" class="form-control" id="txtPostName" runat="server" placeholder="Tên bài viết" />
                    <textarea id="txtSummaryContent" placeholder="Nội dung tóm tắt" runat="server"></textarea>
                    <input type="text" class="form-control" id="txtDateCreated" runat="server" placeholder="Ngày đăng" readonly />
                    <div class="d-flex gap-3 p-0">
                        <input type="text" class="form-control" id="txtNumReviews" placeholder="Số lượng đánh giá" readonly />
                        <input type="text" class="form-control" id="txtNumRes" placeholder="Số lượng phản hồi" readonly />
                    </div>
                    <textarea id="txtContent" placeholder="Nội dung bài viết" runat="server"></textarea>
                    <asp:Button ID="btnSave" runat="server" Text="Hoàn tất" CssClass="btn btn-success" OnClick="btnSave_Click" />
                </div>

            </asp:Panel>
            <asp:Panel CssClass="panel border border-2 rounded w-50 h-25" runat="server">
                <label class="form-control" style="background-color: cadetblue; font-weight: 600; color: white">Ảnh</label>
                <div class="form-group px-5 py-4 d-flex row gap-3">
                    <input type="text" class="form-control" id="txtLinkImage" runat="server" placeholder="Đường dẫn" />
                </div>
            </asp:Panel>
        </div>
    </div>
    <!-- Tables -->
    <div class="table_panel mb-3">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel CssClass=" mt-2 px-5 py-3" ID="pnTable" runat="server">
                    <div class="row ml-4">
                        <table class="table table-bordered table-responsive">
                            <label class="form-control" style="background-color: darkcyan; font-weight: 600; color: white">
                                Danh sách bài viết</label>
                            <div class="p-0 d-flex col align-items-center gap-3">
                                    <asp:DropDownList CssClass="dropdown-toggle btn btn-secondary" AutoPostBack="true" ID="dlPageNumber" runat="server" OnSelectedIndexChanged="dlPageNumber_SelectedIndexChanged">
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                    </asp:DropDownList>
                                <div class="col-md-5">
                                    <input type="text" class="form-control" id="txtKeyword" placeholder="Keyword" runat="server">
                                </div>
                                <button class="btn btn-primary mb-2" runat="server" name="btn-search" onserverclick="btnSearch_ServerClick">Tìm kiếm</button>
                                <button class="btn btn-danger mb-2" runat="server" name="btn-delete" onserverclick="btnDelete_ServerClick">Xóa</button>
                            </div>
                            <thead class="table-secondary">
                                <tr class="text-center text-nowrap">
                                    <th>
                                        <input id="selectAll" type="checkbox">
                                    <th>Mã bài viết</th>
                                    <th>Tên bài viết</th>
                                    <th>Ngày đăng</th>
                                    <th>SL đánh giá</th>
                                    <th>SL phản hồi</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var item in ls) 
                                    { %>
                                <tr>
                                    <td style="width: 40px; text-align: center">
                                        <input name='cbID' type='checkbox' value='<%= item.ID %>' /> 
                                    </td>
                                    <td><%=item.ID %></td>
                                    <td><%=item.Title %></td>
                                    <td><%=item.NgayDang %></td>
                                    <td><%=item.NumberOfReviews %></td>
                                    <td><%=item.NumberOfResponse %></td>
                                    <td>
                                        <a class="btn btn-primary" href="?idEdit=<%=item.ID %>" style="text-align: center">Sửa</a>
                                    </td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="card-footer text-right" style="margin-top: 10px;">
        <asp:Panel ID="pnPhanTrang" runat="server">
            <div class="form-row" style="display: flex; gap: 5px; justify-content: center;">
                <div class="col-auto">
                    <asp:Button ID="btTruoc" runat="server" Text="Trước" class="btn btn-dark" OnClick="btPhanTrang_Click"/>
                </div>
                <div class="col-auto">
                    <asp:HiddenField ID="hPageIndex" runat="server" />
                    <asp:HiddenField ID="hTotalRows" runat="server" />
                    <asp:HiddenField ID="hPageSize" runat="server" />
                    <asp:Panel ID="pnButton" runat="server" Style="display: flex; gap: 2px;"></asp:Panel>

                </div>
                <div class="col-auto">
                    <asp:Button ID="btSau" runat="server" Text="Sau" class="btn  btn-dark" OnClick="btPhanTrang_Click"/>
                </div>
            </div>
        </asp:Panel>
    </div>
    <script>
        $("#selectAll").click(function () {
            $("input[type=checkbox]").prop('checked', $(this).prop('checked'));
        })
    </script>
</asp:Content>
