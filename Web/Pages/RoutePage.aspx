<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoutePage.aspx.cs" Inherits="Web.Pages.RoutePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý lộ trình</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous" />
</head>
<body>
    <div class="" style="margin-left: 48px; margin-right: 48px; margin-top: 24px;">
        <form id="form1" runat="server">
            <div class="row">
                <div class="col-sm-6">
                    <h2>Danh sách lộ trình: </h2>
                    <div runat="server" class="overflow-auto" style="margin-top: 24px">
                        <asp:GridView Style="width: 1800px" ID="GridViewRoute" CssClass="table table-bordered table-striped" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridViewRoute_SelectedIndexChanged"></asp:GridView>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="" style="margin-left: 0; margin-right: 0; margin-top: 48px">
                        <div class="form-group">
                            <div class="row">
                                <label>Mã lộ trình</label>
                                <div class="col-sm-10">
                                    <asp:TextBox CssClass="form-control" ReadOnly="true" runat="server" TextMode="SingleLine" ID="IDRoute" placeholder="Mã lộ trình" />
                                    <small class="form-text text-muted">Xác nhận lộ trình nào được cập nhật hay xóa, tăng tự động khi thêm.</small>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Button Text="Xóa" runat="server" Style="width: 100%" ID="btnDelete" CssClass="btn btn-primary" OnClick="ButtonDeleteRoute_Click" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label>Tên lộ trình</label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="SingleLine" ID="RouteName" placeholder="Tên lộ trình"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <label>Tên Tuyến</label>
                                    <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="dlIDBusRoutes" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <label>Tên Điểm bắt đầu</label>
                                    <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="dlIDStartPosition" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>


                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <label>Tên Điểm kết thúc</label>
                                    <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="dlIDEndPosition" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-6">
                                    <label>Số chuyến</label>
                                    <asp:TextBox type="number" class="form-control" placeholder="0" min="1" max="100" runat="server" ID="RouteAmount" />
                                </div>
                                <div class="col-sm-6">
                                    <label>Thời gian chuyến</label>
                                    <asp:TextBox type="number" class="form-control" placeholder="0" min="1" max="100" runat="server" ID="RouteTime" />
                                    <small class="form-text text-muted">Số phút hoàn thành một chuyến.</small>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-6">
                                    <label>Thời gian bắt đầu hoạt động</label>
                                    <asp:TextBox runat="server" ID="StartTime" CssClass="form-control" TextMode="Time" />
                                </div>
                                <div class="col-sm-6">
                                    <label>Thời gian kết thúc hoạt động</label>
                                    <asp:TextBox runat="server" ID="EndTime" CssClass="form-control" TextMode="Time"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label>Ngày áp dụng</label>
                            <asp:TextBox runat="server" ID="ApplicableDate" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Ngày hoạt động</label>
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:CheckBoxList runat="server" CssClass="form-control" ID="OperationDate">
                                        <asp:ListItem>Thứ 2</asp:ListItem>
                                        <asp:ListItem>Thứ 3</asp:ListItem>
                                        <asp:ListItem>Thứ 4</asp:ListItem>
                                        <asp:ListItem>Thứ 5</asp:ListItem>
                                        <asp:ListItem>Thứ 6</asp:ListItem>
                                        <asp:ListItem>Thứ 7</asp:ListItem>
                                        <asp:ListItem>Chủ nhật</asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row mt-3">
                            <div class="col-sm-4">
                                <asp:Button runat="server" Text="Cập nhật" CssClass="btn btn-primary" Style="width: 100%" OnClick="ButtonUpdateRoute_Click" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Button runat="server" Text="Thêm" CssClass="btn btn-primary" Style="width: 100%" OnClick="ButtonAddRoute_Click" />
                            </div>
                        </div>

                    </div>

                </div>
            </div>


        </form>
    </div>
</body>
</html>
